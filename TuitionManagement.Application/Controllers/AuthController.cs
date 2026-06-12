
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuitionManagement.Data.Models;

namespace TuitionManagement.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController (UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
    }
}
