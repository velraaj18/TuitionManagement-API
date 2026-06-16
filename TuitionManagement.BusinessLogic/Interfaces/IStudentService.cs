using System.ComponentModel.DataAnnotations;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.BusinessLogic.Interfaces
{
    public interface IStudentService
    {
       Task<APIResponse<List<StudentResponse>>> GetAllStudents();
       Task<APIResponse<StudentDetailResponse?>> GetStudentById(int studentId);
       Task<APIResponse<StudentDetailResponse?>> CreateStudent(CreateStudentRequest req, string userName);
    }
}