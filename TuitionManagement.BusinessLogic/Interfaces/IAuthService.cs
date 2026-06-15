using System.ComponentModel.DataAnnotations;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task<APIResponse<string>> RegisterUser(CreateUserRequest request);
    }
}