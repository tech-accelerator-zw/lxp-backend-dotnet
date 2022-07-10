using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class InstituteRepository : IInstituteRepository
    {
        public Task<Result<Institute>> AddAsync(InstituteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Institute>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}