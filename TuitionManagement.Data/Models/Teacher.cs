using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionManagement.Data.Models
{
    public class Teacher : BaseAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherUID { get; set; }

        [Required]
        [StringLength(100)]
        public string TeacherName { get; set; }

        [Phone]
        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        public ICollection<BatchSchedule> BatchSchedules { get; set; }
    }
}