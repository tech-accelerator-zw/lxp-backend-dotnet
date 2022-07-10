using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public interface IInstituteRepository
    {
        Task<Result<Institute>> AddAsync(InstituteRequest request);
        Task<Result<IEnumerable<Institute>>> GetAllAsync();
    }
}