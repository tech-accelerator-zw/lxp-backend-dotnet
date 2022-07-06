using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;
using UserManagement.API.Models.Data;
using UserManagement.API.Models.Repository;

namespace UserManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository) => _roleRepository = roleRepository;
       
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RoleRequest request)
        {
            var result = await _roleRepository.AddAsync(new Role
            {
                Name = request.RoleName
            });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _roleRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _roleRepository.GetByIdAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleRequest request)
        {
            var result = await _roleRepository.UpdateAsync(new Role
            {
                Id = request.Id,
                Name = request.RoleName
            });

            return Ok(result);
        }
    }
}