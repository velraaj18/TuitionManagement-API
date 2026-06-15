using Microsoft.EntityFrameworkCore;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;

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

            return new APIResponse<List<StudentResponse>>() { StatusCode = APIStatusCodes.Success, Data = result, Message = "Student records retrieved successfully" };
        }

        public async Task<APIResponse<StudentDetailResponse?>> GetStudentById(int studentId)
        {
            var response = await _db.Students.Where(x => x.StudentUID == studentId).Select(x => new StudentDetailResponse
            {
                StudentName = x.StudentName,
                StudentUID = x.StudentUID,
                PhoneNumber = x.PhoneNumber,
                EmailAddress = x.EmailAddress,
                Batches = x.StudentBatches.Select(x => new StudentBatchResponse
                {
                    BatchName = x.Batch.BatchName,
                    BatchUID = x.Batch.BatchUID,
                    JoinedDate = x.Batch.DateCreated
                }).ToList()
            }).FirstOrDefaultAsync();

            if (response == null)
            {
                return new APIResponse<StudentDetailResponse?>() { StatusCode = APIStatusCodes.NotFound, Data = null, Message = "Student record not found" };
            }

            return new APIResponse<StudentDetailResponse?>() { StatusCode = APIStatusCodes.Success, Data = response, Message = "Student records retrieved successfully" };
        }

        public async Task<APIResponse<StudentResponse>> CreateStudent(CreateStudentRequest req, string userName)
        {
            if (req == null)
            {
                return new APIResponse<StudentResponse>() { StatusCode = APIStatusCodes.BadRequest, Data = null, Message = "Request Cannot be null" };
            }



            var student = new Student
            {
                StudentName = req.StudentName,
                EmailAddress = req.EmailAddress,
                PhoneNumber = req.PhoneNumber,
                DateCreated = DateTime.UtcNow
            };
        }
    }
}