using Business.Abstract;
using Core.Identity.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginWithGoogle([FromBody]GoogleLoginUserRequest request)
        {
            var accessToken= await _userService.GoogleLoginAsync(request);
            return Ok(accessToken);
        }
    }
}
