using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class CreateRegisterRequest
    {
        [MaxLength]
        public string Email { get; set; } = string.Empty;
        [MaxLength]
        public string Password { get; set; } = string.Empty;
        [MaxLength]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength]
        public string LastName { get; set; } = string.Empty;
    }
}