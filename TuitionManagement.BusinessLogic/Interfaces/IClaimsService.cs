using System.ComponentModel.DataAnnotations;

namespace TuitionManagement.BusinessLogic.Interfaces
{
    public interface IClaimsService
    {
        string GetUserName();
        string GetUserId();
        string GetEmail();
    }
}