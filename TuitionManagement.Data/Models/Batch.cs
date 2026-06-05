using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TuitionManagement.Data.Models
{
    public class Batch : BaseAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BatchUID { get; set; }
        [Required]
        [StringLength(50)]
        public string BatchName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public int MaxStrength { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal MonthlyFee { get; set; }
        public ICollection<StudentBatch> StudentBatches { get; set; }
        public ICollection<BatchSchedule> BatchSchedules { get; set; }
    }
}