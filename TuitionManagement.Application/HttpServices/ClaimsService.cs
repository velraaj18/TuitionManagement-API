using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TuitionManagement.BusinessLogic.Interfaces;

namespace TuitionManagement.Application.HttpServices
{
    public class ClaimsService : IClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
        }

        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public string GetEmail()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}