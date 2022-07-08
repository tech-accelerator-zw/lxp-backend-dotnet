using ModelLibrary;

namespace UserManagement.API.Models.Repository
{
    public interface IStudentRepository
    {
        Task<Result<Student>> AddAsync(Student student);
        Task<Result<IEnumerable<Student>>> GetAllAsync();
    }
}