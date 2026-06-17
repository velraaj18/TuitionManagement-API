using System.ComponentModel.DataAnnotations;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task<APIResponse<string>> RegisterUser(CreateRegisterRequest request);
        Task<APIResponse<GetLoginResponse>> Login(CreateLoginRequest request);
        Task<APIResponse<GetLoginResponse>> Refresh(CreateRefreshTokenRequest request);
    }
}