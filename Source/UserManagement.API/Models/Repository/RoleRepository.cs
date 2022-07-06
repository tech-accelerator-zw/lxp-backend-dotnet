using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) => _context = context;

        public async Task<Result<Role>> AddAsync(Role role)
        {
            await _context.Roles!.AddAsync(role);
            await _context.SaveChangesAsync();

            return new Result<Role>(role);
        }

        public async Task<Result<IEnumerable<Role>>> GetAllAsync()
        {
            var roles = await _context.Roles!.ToListAsync();
            return new Result<IEnumerable<Role>>(roles);
        }

        public async Task<Result<Role>> GetByIdAsync(int id)
        {
            var role = await _context.Roles!.SingleOrDefaultAsync(x => x.Id == id);
            if (role == null) return new Result<Role>(false, "Role not found");

            return new Result<Role>(role);
        }

        public async Task<Result<Role>> UpdateAsync(Role role)
        {
            _context.Update(role);
            await _context.SaveChangesAsync();

            return new Result<Role>(role);
        }
    }
}