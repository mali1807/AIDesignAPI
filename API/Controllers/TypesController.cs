using Business.Abstract;
using Business.DTOs.Requests.Types;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddType([FromBody]CreateTypeRequest request)
        {
            var result =await _typeService.CreateTypeAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListTypes([FromQuery]PageRequest request)
        {
            var result = await _typeService.GetListTypeAsync(request);
            return Ok(result);
        }
    }
}
