using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<APIResponse<List<GetSubjectResponse>>> GetAllSubjects()
        {
            var response = await _service.GetAllSubjects();
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<APIResponse<GetSubjectDetailResponse>> GetSubjectById(int id)
        {
            var response = await _service.GetSubjectById(id);
            return response;
        }

        [HttpPost]
        [Authorize]
        public async Task<APIResponse<GetSubjectDetailResponse>> CreateSubject(CreateSubjectRequest req)
        {
            var response = await _service.CreateSubject(req);
            return response;
        }
    }
}