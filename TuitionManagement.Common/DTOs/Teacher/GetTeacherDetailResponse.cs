namespace TuitionManagement.Common.DTOs
{
    public class GetTeacherDetailResponse : BaseAuditFields
    {
        public int TeacherUID { get; set; }
        public string TeacherName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }

        public List<TeacherBatchResponse> Batches { get; set; }
    }

    public class TeacherBatchResponse
    {
        public int BatchUID { get; set; }
        public string BatchName { get; set; }

        public DayOfWeek Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}