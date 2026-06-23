namespace TuitionManagement.Common.DTOs
{
    public class GetSubjectDetailResponse : BaseAuditFields
    {
        public int SubjectUID { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }

        public List<SubjectBatchResponse> Batches { get; set; }
    }

    public class SubjectBatchResponse
    {
        public int BatchUID { get; set; }
        public string BatchName { get; set; }
    }
}