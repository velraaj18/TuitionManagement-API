namespace TuitionManagement.Common.DTOs
{
    public class BaseAuditFields
    {
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}