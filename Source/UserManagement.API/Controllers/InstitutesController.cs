using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models.Data;
using UserManagement.API.Models.Repository;

namespace UserManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InstitutesController : ControllerBase
    {
        private readonly IInstituteRepository _instituteRepository;

        public InstitutesController(IInstituteRepository instituteRepository)
        {
            _instituteRepository = instituteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(InstituteRequest request)
        {
            var result = await _instituteRepository.AddAsync(request);

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}