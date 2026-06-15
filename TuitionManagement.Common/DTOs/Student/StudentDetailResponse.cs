using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class StudentDetailResponse : BaseAuditFields
    {
        public int StudentUID { get; set; }
        public string StudentName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public List<StudentBatchResponse> Batches { get; set; }
    }
}