using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionManagement.Data.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentUID { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }

        [Phone]
        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }
        
        public string ModifiedBy { get; set; }

    }
}