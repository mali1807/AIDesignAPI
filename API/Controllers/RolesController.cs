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
            if (result)
                return Ok("Role created successfully.");
            else
                return BadRequest("Failed to create role.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleRequest request)
        {
            var result = await _roleService.DeleteRoleAsync(request);
            if (result)
                return Ok("Role deleted successfully.");
            else
                return BadRequest("Failed to delete role.");
        }


        [HttpPut]
        public async Task<IActionResult> ChangeUserRole([FromBody] UpdateRoleRequest request)
        {
            var result = await _roleService.ChangeUserRoleAsync(request.UserId, request.RoleName);
            if (result)
                return Ok("User role changed successfully.");
            else
                return BadRequest("Failed to change user role.");
        }
    }
}
