using ModelLibrary;

namespace UserManagement.API.Models.Repository
{
    public interface IStudentRepository
    {
        Task<Result<Student>> AddAsync(StudentRequest request);
        Task<Result<IEnumerable<Student>>> GetAllAsync();
    }
}