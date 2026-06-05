using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionManagement.Data.Models
{
    public class Subject : BaseAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectUID { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public ICollection<BatchSchedule> BatchSchedules { get; set; }
    }
}