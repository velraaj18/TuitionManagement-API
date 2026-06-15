using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;

namespace TuitionManagement.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<APIResponse<string>> RegisterUser(CreateRegisterRequest request)
        {
            if (request == null)
            {
                return new APIResponse<string>() { Data = "Request Cannot be null", Message = "Request Cannot be null", StatusCode = APIStatusCodes.BadRequest };
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
                return new APIResponse<string>() { Data = "", Message = errors, StatusCode = APIStatusCodes.BadRequest };
            }

            var userRole = await _userManager.AddToRoleAsync(user, "Student");

            if (!userRole.Succeeded)
            {
                var errors = string.Join(", ", userRole.Errors.Select(e => e.Description));
                return new APIResponse<string>() { Data = "", Message = errors, StatusCode = APIStatusCodes.BadRequest };
            }

            return new APIResponse<string>() { Data = "Success", Message = "Success", StatusCode = APIStatusCodes.Success };
        }

        public async Task<APIResponse<GetLoginResponse>> Login(CreateLoginRequest request)
        {
            if (request == null)
            {
                return new APIResponse<GetLoginResponse>() { Data = new GetLoginResponse(), Message = "Request Cannot be null", StatusCode = APIStatusCodes.BadRequest };
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new APIResponse<GetLoginResponse>() { Data = new GetLoginResponse(), Message = "Invalid username or password", StatusCode = APIStatusCodes.NotFound };
            }

            var verifyPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!verifyPassword)
            {
                return new APIResponse<GetLoginResponse>() { Data = new GetLoginResponse(), Message = "Invalid username or password", StatusCode = APIStatusCodes.BadRequest };
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var jwtToken = GenerateJwtToken(user, userRoles);

            var response = new GetLoginResponse
            {
                JwtToken = jwtToken
            };

            // Todo : Need to create refresh token also.

            return new APIResponse<GetLoginResponse>(){Data = response, Message= "Login Successful", StatusCode = APIStatusCodes.Success};
        }

        private string GenerateJwtToken(ApplicationUser user, IList<string> roles)
        {
            var  claims = new List<Claim>{
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Step 1: generate key using the byte version of SecretKey from the JwtSettings      
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            // Step 2: generate signing cred using the key
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Step 3: generate token using issuer, audience, claims, expiry and signing cred
            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience : _jwtSettings.Audience,
                claims : claims,
                expires : DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials : signingCredentials
            );

            // Step 4: convert the JwtSecurityToken object into string token
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}