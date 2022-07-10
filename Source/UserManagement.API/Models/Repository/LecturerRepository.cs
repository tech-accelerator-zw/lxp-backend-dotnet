using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class LecturerRepository : ILecturerRepository
    {
        public Task<Result<Lecturer>> AddAsync(LecturerRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Lecturer>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}