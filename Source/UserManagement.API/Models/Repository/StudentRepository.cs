using ModelLibrary;

namespace UserManagement.API.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Task<Result<Student>> AddAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Student>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}