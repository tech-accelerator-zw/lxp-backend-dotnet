using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public interface ILecturerRepository
    {
        Task<Result<Lecturer>> AddAsync(LecturerRequest request);
        Task<Result<IEnumerable<Lecturer>>> GetAllAsync(); 
    }
}