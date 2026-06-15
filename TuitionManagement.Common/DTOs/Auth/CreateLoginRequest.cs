using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class CreateLoginRequest
    {
        [MaxLength]
        public string Email { get; set; } = string.Empty;
        [MaxLength]
        public string Password { get; set; } = string.Empty;
    }
}