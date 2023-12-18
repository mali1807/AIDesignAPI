using Autofac.Core;
using Business.Abstract;
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
        public async Task<IActionResult> AddType([FromBody] CreateDraftRequest request)
        {
            var result = await _draftService.CreateDraftAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListTypes([FromQuery] PageRequest request)
        {
            var result = await _draftService.GetListDraftAsync(request);
            return Ok(result);
        }
    }
}
