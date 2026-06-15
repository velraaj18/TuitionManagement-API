using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.Common.DTOs
{
    public class StudentBatchResponse
    {
        public int BatchUID { get; set; }
        public string BatchName { get; set; }

        public DateTime JoinedDate { get; set; }
    }
}