using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class CreateSubjectRequest
    {
        public int? SubjectUID { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
    }
}