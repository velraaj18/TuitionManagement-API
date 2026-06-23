namespace TuitionManagement.Common.DTOs
{
    public class GetSubjectResponse : BaseAuditFields
    {
        public int SubjectUID { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }

        public int BatchCount { get; set; }
    }
}