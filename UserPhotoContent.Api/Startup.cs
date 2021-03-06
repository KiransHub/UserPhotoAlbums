using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserPhotoContent.Common.Contracts.Services;
using UserPhotoContent.Common.DependencyInjection;
using UserPhotoContent.Data.Contracts.Services;
using UserPhotoContent.Data.Models;
using UserPhotoContent.Domain.Models;
using UserPhotoContent.Domain.Services;

namespace UserPhotoContent.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddUserPhotoContentServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Resources.Constants.SwaggerAppVersion, new OpenApiInfo { Title = Resources.Constants.SwaggerUiAppName, Version = Resources.Constants.SwaggerAppVersion });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
                opt.SwaggerEndpoint(Resources.Constants.SwaggerDataEndpoint, Resources.Constants.SwaggerUiAppName));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
