using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _service.GetAllStudents();
            return Ok(response);
        }

        [HttpGet]
        public async Task<APIResponse<StudentDetailResponse>> GetStudentById(int studentId)
        {
            var response = await _service.GetStudentById(studentId);
            return response;
        }

        [HttpPost]
        [Authorize]
        public async Task<APIResponse<StudentDetailResponse>> CreateStudent(CreateStudentRequest req)
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var response = await _service.CreateStudent(req, userName);
            return response;
        }
    }
}