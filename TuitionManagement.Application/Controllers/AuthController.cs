
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data.Models;

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

        [Authorize(Roles = "Admin")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Authorized");
        }
    }
}
