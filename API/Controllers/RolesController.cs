using Business.Abstract;
using Business.DTOs.Requests.Roles;
using Business.DTOs.Requests.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var result = await _roleService.CreateRoleAsync(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleRequest request)
        {
            var result = await _roleService.DeleteRoleAsync(request);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> ChangeUserRole([FromBody] UpdateRoleRequest request)
        {
            var result = await _roleService.ChangeUserRoleAsync(request);
            return Ok(result);
        }
    }
}
