using System.ComponentModel.DataAnnotations;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.BusinessLogic.Interfaces
{
    public interface ISubjectService
    {
        Task<APIResponse<List<GetSubjectResponse>>> GetAllSubjects();
        Task<APIResponse<GetSubjectDetailResponse>> CreateSubject(CreateSubjectRequest req);
        Task<APIResponse<GetSubjectDetailResponse>> GetSubjectById(int id); 
    }
}