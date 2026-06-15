using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class CreateRefreshTokenRequest
    {
        public string RefreshToken { get; set; }
    }
}