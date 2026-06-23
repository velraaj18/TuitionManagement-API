using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TuitionManagement.BusinessLogic.Interfaces;
using TuitionManagement.BusinessLogic.Services;
using TuitionManagement.Common.DTOs;

namespace TuitionManagement.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<APIResponse<List<GetTeacherResponse>>> GetTeachers()
        {
            var response = await _service.GetAllTeachers();
            return response;
        } 

        [HttpGet]
        [Route("{id}")]
        public async Task<APIResponse<GetTeacherDetailResponse>> GetTeacherById(int id)
        {
            var response = await _service.GetTeacherById(id);
            return response;
        }

        [HttpPost]
        public async Task<APIResponse<GetTeacherDetailResponse>> CreateTeacher(CreateTeacherRequest req)
        {
            var response = await _service.CreateTeacher(req);
            return response;
        }
    }
}