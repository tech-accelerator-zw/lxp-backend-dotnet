using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using UserManagement.API.Enums;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Student>> AddAsync(StudentRequest request)
        {
            var account = await _context.Accounts!.Where(x => x.Id == request.UserId).FirstOrDefaultAsync();
            if (account == null) return new Result<Student>(false, "User account not found!");

            var code = await _context.GeneratedCodes!.Where(x => x.UserEmail == account.Email && x.Code == request.Otp).FirstOrDefaultAsync();
            if (code == null) return new Result<Student>(false, "Invalid OTP provided!");

            account.Status = AccountStatus.Verified;
            account.DateModified = DateTime.Now;

            _context.Accounts!.Update(account);

            var student = new Student
            {
                FirstNames = request.FirstNames,
                LastName = request.LastName,
                UserId = request.UserId,
                DateOfBirth = request.DateOfBirth,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            await _context.Students!.AddAsync(student);

            await _context.SaveChangesAsync();

            return new Result<Student>(student, "Profile registration complete!");
        }

        public Task<Result<IEnumerable<Student>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}