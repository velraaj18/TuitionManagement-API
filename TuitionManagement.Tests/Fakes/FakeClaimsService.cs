using TuitionManagement.BusinessLogic.Interfaces;

namespace TuitionManagement.Tests.Fakes
{
    public class FakeClaimsService : IClaimsService
    {
        public string GetUserName()
        {
            return "TestUser";
        }

        public string GetUserId()
        {
            return "1";
        }

        public string GetEmail()
        {
            return "test@test.com";
        }
    }
}