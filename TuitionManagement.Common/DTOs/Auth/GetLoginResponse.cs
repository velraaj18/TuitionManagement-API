using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class GetLoginResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}