using Microsoft.AspNetCore.Mvc;
using WebApi_Jayasri.Service;

namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET api/students
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Getstudents());
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _service.Getstudent(id);

            return student == null ? NotFound() : Ok(student);
            // commits.
        }
    }
}

