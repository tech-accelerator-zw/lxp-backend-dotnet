using ModelLibrary;

namespace UserManagement.API.Models.Repository
{
    public interface IRoleRepository
    {
        Task<Result<Role>> AddAsync(Role role);
        Task<Result<Role>> UpdateAsync(Role role);
        Task<Result<IEnumerable<Role>>> GetAllAsync();
        Task<Result<Role>> GetByIdAsync(int id);
    }
}