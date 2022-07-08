using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public interface IStudentRepository
    {
        Task<Result<Student>> AddAsync(StudentRequest request);
        Task<Result<IEnumerable<Student>>> GetAllAsync();
    }
}