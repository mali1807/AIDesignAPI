using Business.Abstract;
using Business.DTOs.Requests.Files;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFile([FromQuery] UploadFileRequest request)
        {
            request.Files = Request.Form.Files;
            var result=await _fileService.UploadFileAsync(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListFiles([FromQuery] PageRequest request)
        {
            var result = await _fileService.GetListFileAsync(request);
            return Ok(result); 
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> SoftlyDeleteFile([FromRoute] SoftDeleteFileRequest request)
        {
            var result =await _fileService.SoftDeleteFileAsync(request);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> PermanentlyDeleteFile([FromRoute] PermanentDeleteFileRequest request)
        {
            var result=await _fileService.PermanentDeleteFileAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFile([FromBody] UpdateFileRequest request)
        {
            var result =await _fileService.UpdateFileAsync(request);
            return Ok(result);
        }
    }
}
