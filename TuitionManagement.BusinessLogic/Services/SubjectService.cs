using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.Common.DTOs;
using TuitionManagement.Data;
using TuitionManagement.Data.Models;

namespace TuitionManagement.BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _db;
        private readonly IClaimsService _claimsService;
        public SubjectService(ApplicationDbContext db, IClaimsService claimsService)
        {
            _db = db;
            _claimsService = claimsService;
        }

        public async Task<APIResponse<List<GetSubjectResponse>>> GetAllSubjects()
        {
            var subjects = await _db.Subjects.Select(x => new GetSubjectResponse()
            {
                SubjectUID = x.SubjectUID,
                SubjectName = x.SubjectName,
                Description = x.Description,
                BatchCount = x.BatchSchedules.Select(bs => bs.BatchUID).Distinct().Count(),
                CreatedBy = x.CreatedBy,
                DateCreated = x.DateCreated,
                ModifiedBy = x.ModifiedBy,
                DateModified = x.DateModified
            }).ToListAsync();

            return new APIResponse<List<GetSubjectResponse>>() { Data = subjects, Message = "Retrieved Successfully", StatusCode = APIStatusCodes.Success };
        }

        public async Task<APIResponse<GetSubjectDetailResponse>> GetSubjectById(int id)
        {
            var subject = await _db.Subjects
                .Where(x => x.SubjectUID == id)
                .Select(x => new GetSubjectDetailResponse
                {
                    SubjectUID = x.SubjectUID,
                    SubjectName = x.SubjectName,
                    Description = x.Description,
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    ModifiedBy = x.ModifiedBy,
                    DateModified = x.DateModified,

                    Batches = x.BatchSchedules
                        .Select(bs => new SubjectBatchResponse
                        {
                            BatchUID = bs.Batch.BatchUID,
                            BatchName = bs.Batch.BatchName
                        })
                        .Distinct()
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (subject == null)
            {
                return new APIResponse<GetSubjectDetailResponse>
                {
                    StatusCode = APIStatusCodes.NotFound,
                    Message = "Subject not found"
                };
            }

            return new APIResponse<GetSubjectDetailResponse>
            {
                StatusCode = APIStatusCodes.Success,
                Data = subject,
                Message = "Retrieved Successfully"
            };
        }

        public async Task<APIResponse<GetSubjectDetailResponse>> CreateSubject(CreateSubjectRequest req)
        {
            var userName = _claimsService.GetUserName();

            if (req == null)
            {
                return new APIResponse<GetSubjectDetailResponse>() { StatusCode = APIStatusCodes.BadRequest, Data = new GetSubjectDetailResponse(), Message = "Request Cannot be null" };
            }

            var subject = new Subject()
            {
                SubjectName = req.SubjectName,
                Description = req.Description,
                DateCreated = DateTime.UtcNow,
                CreatedBy = userName,
            };

            _db.Subjects.Add(subject);
            await _db.SaveChangesAsync();

            return await GetSubjectById(subject.SubjectUID);
        }


    }
}