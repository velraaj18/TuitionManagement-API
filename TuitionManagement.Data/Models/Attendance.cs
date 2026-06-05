using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionManagement.Data.Models
{
    public class Attendance : BaseAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceUID { get; set; }

        [Required]
        public int StudentUID { get; set; }

        [ForeignKey(nameof(StudentUID))]
        public Student Student { get; set; }

        [Required]
        public int BatchUID { get; set; }

        [ForeignKey(nameof(BatchUID))]
        public Batch Batch { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public bool IsPresent { get; set; }
    }
}