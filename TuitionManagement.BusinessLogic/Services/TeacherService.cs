using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;

namespace TuitionManagement.BusinessLogic.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _db;
        private readonly IClaimsService _claimsService;
        public TeacherService(ApplicationDbContext db, IClaimsService claimsService)
        {
            _db = db;
            _claimsService = claimsService;
        }

        public async Task<APIResponse<List<GetTeacherResponse>>> GetAllTeachers()
        {
            var teachers = await _db.Teachers
            .Select(t => new GetTeacherResponse
            {
                TeacherUID = t.TeacherUID,
                TeacherName = t.TeacherName,
                PhoneNumber = t.PhoneNumber,
                EmailAddress = t.EmailAddress,
                Qualification = t.Qualification,
                Experience = t.Experience,
                BatchCount = t.BatchSchedules.Count(),
                CreatedBy = t.CreatedBy,
                DateCreated = t.DateCreated,
                ModifiedBy = t.ModifiedBy,
                DateModified = t.DateModified
            }).ToListAsync();

            return new APIResponse<List<GetTeacherResponse>>() { StatusCode = APIStatusCodes.Success, Data = teachers, Message = "Retrieved Successfully" };
        }

        public async Task<APIResponse<GetTeacherDetailResponse?>> CreateTeacher(CreateTeacherRequest req)
        {
            var userName = _claimsService.GetUserName();
            if (req == null)
            {
                return new APIResponse<GetTeacherDetailResponse?>() { StatusCode = APIStatusCodes.BadRequest, Data = null, Message = "Request Cannot be null" };
            }

            var teacher = new Teacher
            {
                TeacherName = req.TeacherName,
                EmailAddress = req.EmailAddress,
                PhoneNumber = req.PhoneNumber,
                Qualification = req.Qualification,
                Experience = req.Experience,
                DateCreated = DateTime.UtcNow,
                CreatedBy = userName,
            };
            _db.Teachers.Add(teacher);
            await _db.SaveChangesAsync();

            return await GetTeacherById(teacher.TeacherUID);
        }

        public async Task<APIResponse<GetTeacherDetailResponse?>> GetTeacherById(int id)
        {
            var teacher = await _db.Teachers
                .Where(t => t.TeacherUID == id)
                .Select(t => new GetTeacherDetailResponse
                {
                    TeacherUID = t.TeacherUID,
                    TeacherName = t.TeacherName,
                    PhoneNumber = t.PhoneNumber,
                    EmailAddress = t.EmailAddress,
                    Qualification = t.Qualification,
                    Experience = t.Experience,
                    CreatedBy = t.CreatedBy,
                    DateCreated = t.DateCreated,
                    ModifiedBy = t.ModifiedBy,
                    DateModified = t.DateModified

                    // Add BatchSchedules mapping here if your DTO contains it
                })
                .FirstOrDefaultAsync();

            if (teacher == null)
            {
                return new APIResponse<GetTeacherDetailResponse?>
                {
                    StatusCode = APIStatusCodes.NotFound,
                    Message = "Teacher not found"
                };
            }

            return new APIResponse<GetTeacherDetailResponse?>
            {
                StatusCode = APIStatusCodes.Success,
                Data = teacher,
                Message = "Teacher retrieved successfully"
            };
        }
    }
}