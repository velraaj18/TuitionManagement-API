using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuitionManagement.Data.Models
{
    public class Payment : BaseAuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentUID { get; set; }

        [Required]
        public int StudentUID { get; set; }

        [ForeignKey(nameof(StudentUID))]
        public Student Student { get; set; }

        [Required]
        public int BatchUID { get; set; }

        [ForeignKey(nameof(BatchUID))]
        public Batch Batch { get; set; }

        [Required]
        public decimal AmountPaid { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentMode { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }
    }
}