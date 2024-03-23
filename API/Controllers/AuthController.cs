using Business.Abstract;
using Business.DTOs.Requests.Auth;
using Core.Identity.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginWithGoogle([FromBody]GoogleLoginUserRequest request)
        {
            var accessToken= await _authService.GoogleLoginAsync(request);
            return Ok(accessToken);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleRequest request)
        {
            var response = await _authService.AssignRoleToUser(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveRoleToUser([FromBody] RemoveRoleRequest request)
        {
            var response = await _authService.RemoveRoleToUser(request);
            return Ok(response);
        }
    }
}
