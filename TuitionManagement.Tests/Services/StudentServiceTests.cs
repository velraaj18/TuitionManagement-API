using Microsoft.EntityFrameworkCore;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;
using Xunit;

namespace TuitionManagement.Tests.Services
{
    public class StudentServiceTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task CreateStudent_WhenRequestIsNull_ReturnsBadRequest()
        {
            // Arrange
            var db = GetDbContext();
            var service = new StudentService(db);

            // Act
            var result = await service.CreateStudent(null, "Velraaj");

            // Assert
            Assert.Equal(APIStatusCodes.BadRequest, result.StatusCode);
            Assert.Null(result.Data);
            Assert.Equal("Request Cannot be null", result.Message);
        }

        [Fact]
        public async Task CreateStudent_WhenRequestIsValid_ReturnsSuccess()
        {
            // arrange
            var db = GetDbContext();
            var service = new StudentService(db);
            var request = new CreateStudentRequest
            {
                StudentName = "Velraaj",
                EmailAddress = "test@gmail.com",
                PhoneNumber = "1234567890",
            };

            // act
            var result = await service.CreateStudent(request, "velraaj");

            // assert
            Assert.Equal(APIStatusCodes.Success, result.StatusCode);
            Assert.NotNull(result.Data);
        }
    }
}