using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models.Data;
using UserManagement.API.Models.Repository;

namespace UserManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentRequest studentRequest)
        {
            var result = await _studentRepository.AddAsync(studentRequest); 

            if(!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}