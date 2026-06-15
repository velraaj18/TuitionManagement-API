
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

        public AuthController (IAuthService authService)
        {
            _authservice = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<APIResponse<string>> Register(CreateUserRequest req)
        {
            var result = await _authservice.RegisterUser(req);
            return result;
        }
    }
}
