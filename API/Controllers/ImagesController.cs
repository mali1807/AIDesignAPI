﻿using Business.Abstract;
using Business.DTOs.Requests.Images;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromQuery] UploadImageRequest request)
        {
            request.Files = Request.Form.Files;
            var result = await _imageService.UploadImageAsync(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListImages([FromQuery] PageRequest request)
        {
            var result = await _imageService.GetListImageAsync(request);
            return Ok(result);
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> SoftlyDeleteImage([FromRoute] SoftDeleteImageRequest request)
        {
            var result = await _imageService.SoftDeleteImageAsync(request);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> PermanentlyDeleteImage([FromRoute] PermanentDeleteImageRequest request)
        {
            var result = await _imageService.PermanentDeleteImageAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateImage([FromBody] UpdateImageRequest request)
        {
            //todo parametreler null olarak geldiğinde mapper null'ı false yapıyor, bilgilerin tam olarak gönderilmesi lazım
            var result = await _imageService.UpdateImageAsync(request);
            return Ok(result);
        }
    }
}
