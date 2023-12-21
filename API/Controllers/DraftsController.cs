using Autofac.Core;
using Business.Abstract;
using Business.DTOs.Requests.DraftImages;
using Business.DTOs.Requests.Drafts;
using Business.DTOs.Requests.Types;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftsController : ControllerBase
    {
        private readonly IDraftService _draftService;

        public DraftsController(IDraftService draftService)
        {
            _draftService = draftService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDraft([FromBody] CreateDraftRequest request)
        {
            var result = await _draftService.CreateDraftAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListDrafts([FromQuery] PageRequest request)
        {
            var result = await _draftService.GetListDraftAsync(request);
            return Ok(result);
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> SoftlyDeleteDraft([FromRoute] SoftDeleteDraftRequest request)
        {
            var result = await _draftService.SoftDeleteDraftAsync(request);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> PermanentlyDeleteDraft([FromRoute] PermanentDeleteDraftRequest request)
        {
            var result = await _draftService.PermanentDeleteDraftAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDraft([FromBody] UpdateDraftRequest request)
        {
            var result = await _draftService.UpdateDraftAsync(request);
            return Ok(result);
        }
    }
}
