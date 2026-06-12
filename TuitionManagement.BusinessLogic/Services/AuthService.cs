using Microsoft.AspNetCore.Identity;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;

namespace TuitionManagement.BusinessLogic.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService (ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
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

            var result = _userManager.CreateAsync(user, request.Password);

            if (!result.IsCompletedSuccessfully)
            {
                return new APIResponse<string>(){Data = "", Message= "Error", StatusCode = APIStatusCodes.BadRequest};
            }

            return new APIResponse<string>(){Data = "Success", Message= "Success", StatusCode = APIStatusCodes.Success};
        }
    }
}