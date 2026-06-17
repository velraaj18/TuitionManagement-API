
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;

        public AuthController(IAuthService authService)
        {
            _authservice = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<APIResponse<string>> Register(CreateRegisterRequest req)
        {
            var result = await _authservice.RegisterUser(req);
            return result;
        }

        [HttpPost]
        [Route("login")]
        public async Task<APIResponse<GetLoginResponse>> Login(CreateLoginRequest request)
        {
            var result = await _authservice.Login(request);
            return result;
        }

        [HttpPost]
        [Route("refreshToken")]
        public async Task<APIResponse<GetLoginResponse>> RefreshToken(CreateRefreshTokenRequest req)
        {
            var result = await _authservice.Refresh(req);
            return result;
        }

        [Authorize(Roles = "Student")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Authorized");
        }
    }
}
