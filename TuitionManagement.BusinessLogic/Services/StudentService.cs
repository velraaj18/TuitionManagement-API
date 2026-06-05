using Microsoft.EntityFrameworkCore;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;

namespace TuitionManagement.BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _db;
        public StudentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<APIResponse<List<StudentResponse>>> GetAllStudents()
        {
            try
            {
                var result = await _db.Students.Select(x => new StudentResponse
                {
                    StudentUID = x.StudentUID,
                    StudentName = x.StudentName,
                    PhoneNumber = x.PhoneNumber,
                    EmailAddress = x.EmailAddress,
                    DateCreated = x.DateCreated,
                    DateModified = x.DateModified,
                    CreatedBy = x.CreatedBy,
                    ModifiedBy = x.ModifiedBy,
                    BatchCount = x.StudentBatches.Count()
                }).ToListAsync();

                return new APIResponse<List<StudentResponse>>(){StatusCode= APIStatusCodes.Success, Data = result, Message = "Student records retrieved successfully"};
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}