namespace TuitionManagement.Common.DTOs
{
    public class GetTeacherResponse : BaseAuditFields
    {
        public int TeacherUID { get; set; }
        public string TeacherName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }

        public int BatchCount { get; set; }
    }
}