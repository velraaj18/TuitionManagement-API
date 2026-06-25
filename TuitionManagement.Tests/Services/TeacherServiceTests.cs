using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Tests.Fakes;

namespace TuitionManagement.Tests.Services
{
    public class TeacherServiceTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new ApplicationDbContext(options);
        }
        
        [Fact]
        public async Task CreateTeacher_WhenRequestIsNull_ReturnsBadRequest()
        {
            // arrange
            var db = GetDbContext();
            var service = new FakeClaimsService();
            var teacherService = new TeacherService(db, claimsService: service);

            // act
            var result = await teacherService.CreateTeacher(null);

            // assert
            Assert.Equal(APIStatusCodes.BadRequest, result.StatusCode);
            Assert.Null(result.Data);
            Assert.Equal("Request Cannot be null", result.Message);
        }
    }
}