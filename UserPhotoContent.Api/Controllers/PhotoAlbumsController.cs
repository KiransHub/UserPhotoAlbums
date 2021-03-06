﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserPhotoContent.Common.Contracts.Services;
using UserPhotoContent.Domain.Models;

namespace UserPhotoContent.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoAlbumsController : ControllerBase
    {
        private readonly ILogger<PhotoAlbumsController> _logger;
        private readonly IUserContentService<PhotoAlbumModel> _photoAlbumsContentService;


        public PhotoAlbumsController(
            ILogger<PhotoAlbumsController> logger,
            IUserContentService<PhotoAlbumModel> photoAlbumsContentService
            )
        {
            _logger = logger;
            _photoAlbumsContentService = photoAlbumsContentService;
        }

        [HttpGet]
        public IActionResult Get(int userId)
        {
            var result = _photoAlbumsContentService.Get(userId);

            if (result.Any() == false)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }
    }
}
