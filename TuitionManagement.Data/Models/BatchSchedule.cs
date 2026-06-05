using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionManagement.Data.Models
{
    public class BatchSchedule : BaseAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BatchScheduleUID { get; set; }
        public int BatchUID { get; set; }
        [ForeignKey(nameof(BatchUID))]
        public Batch Batch { get; set; }

        public int SubjectUID { get; set; }
        [ForeignKey(nameof(SubjectUID))]
        public Subject Subject { get; set; }

        public int TeacherUID { get; set; }
        [ForeignKey(nameof(TeacherUID))]
        public Teacher Teacher { get; set; }
    }
}