using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Data.Models
{
    public abstract class BaseAuditEntity
    {
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }
    }
}