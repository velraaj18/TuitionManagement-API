using Microsoft.AspNetCore.Identity;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;

namespace TuitionManagement.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService (UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<APIResponse<string>> RegisterUser(CreateUserRequest request) 
        {
            if(request == null)
            {
                return new APIResponse<string>(){Data = "Request Cannot be null", Message= "Request Cannot be null", StatusCode = APIStatusCodes.BadRequest};
            }

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
            };

            var userResult = await _userManager.CreateAsync(user, request.Password);

            if (!userResult.Succeeded)
            {
                var errors = string.Join(", ", userResult.Errors.Select(e => e.Description));
                return new APIResponse<string>(){Data = "", Message= errors, StatusCode = APIStatusCodes.BadRequest};
            }

            var userRole = await _userManager.AddToRoleAsync(user, "Student");

            if (!userRole.Succeeded)
            {
                var errors = string.Join(", ", userRole.Errors.Select(e => e.Description));
                return new APIResponse<string>(){Data = "", Message= errors, StatusCode = APIStatusCodes.BadRequest};
            }

            return new APIResponse<string>(){Data = "Success", Message= "Success", StatusCode = APIStatusCodes.Success};
        }
    }
}