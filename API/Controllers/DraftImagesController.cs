using Business.Abstract;
using Business.DTOs.Requests.DraftImages;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftImagesController : ControllerBase
    {
        private readonly IDraftImageService _draftImageService;

        public DraftImagesController(IDraftImageService draftImageService)
        {
            _draftImageService = draftImageService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDraftImage([FromBody] CreateDraftImageRequest request)
        {
            var result=await _draftImageService.CreateDraftImageAsync(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListDraftImages([FromQuery] PageRequest request)
        {
            var result = await _draftImageService.GetListDraftImageAsync(request);
            return Ok(result); 
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> SoftlyDeleteDraftImage([FromRoute] SoftDeleteDraftImageRequest request)
        {
            var result =await _draftImageService.SoftDeleteDraftImageAsync(request);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> PermanentlyDeleteDraftImage([FromRoute] PermanentDeleteDraftImageRequest request)
        {
            var result=await _draftImageService.PermanentDeleteDraftImageAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDraftImage([FromBody] UpdateDraftImageRequest request)
        {
            var result =await _draftImageService.UpdateDraftImageAsync(request);
            return Ok(result);
        }
    }
}
