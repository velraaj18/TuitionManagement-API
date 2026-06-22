using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class CreateTeacherRequest
    {
        public int? TeacherUID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string TeacherName { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string Qualification { get; set; }

        [Range(0, 50)]
        public int Experience { get; set; }
    }
}