using ModelLibrary;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Task<Result<Student>> AddAsync(StudentRequest student)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Student>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}