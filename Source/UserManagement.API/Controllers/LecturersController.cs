using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models.Data;
using UserManagement.API.Models.Repository;

namespace UserManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerRepository _lecturerRepository;

        public LecturersController(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(LecturerRequest request)
        {
            var result = await _lecturerRepository.AddAsync(request);
            if(!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}