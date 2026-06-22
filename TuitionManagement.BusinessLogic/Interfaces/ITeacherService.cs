using System.ComponentModel.DataAnnotations;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.BusinessLogic.Interfaces
{
    public interface ITeacherService
    {
        Task<APIResponse<List<GetTeacherResponse>>> GetAllTeachers();
        Task<APIResponse<GetTeacherDetailResponse>> CreateTeacher(CreateTeacherRequest request);
        Task<APIResponse<GetTeacherDetailResponse>> GetTeacherById(int id);
    }
}