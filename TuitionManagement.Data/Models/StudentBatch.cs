using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionManagement.Data.Models
{
    public class StudentBatch : BaseAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentBatchUID { get; set; }

        public int StudentUID { get; set; }
        [ForeignKey(nameof(StudentUID))]
        public Student Student { get; set; }

        public int BatchUID { get; set; }
        [ForeignKey(nameof(BatchUID))]
        public Batch Batch { get; set; }
        
        public DateTime JoinedDate { get; set; }
    }
}