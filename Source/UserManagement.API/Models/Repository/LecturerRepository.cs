using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using UserManagement.API.Enums;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class LecturerRepository : ILecturerRepository
    {
        private readonly ApplicationDbContext _context;

        public LecturerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Lecturer>> AddAsync(LecturerRequest request)
        {
            var account = await _context.Accounts!.Where(x => x.Id == request.UserId).FirstOrDefaultAsync();
            if (account == null) return new Result<Lecturer>(false, "User account not found!");

            var code = await _context.GeneratedCodes!.Where(x => x.UserEmail == account.Email && x.Code == request.Otp).FirstOrDefaultAsync();
            if (code == null) return new Result<Lecturer>(false, "Invalid OTP provided!");

            account.Status = AccountStatus.Verified;
            account.DateModified = DateTime.Now;

            _context.Accounts!.Update(account);

            var lecturer = new Lecturer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserId = request.UserId,
                Title = request.Title,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            await _context.Lecturers!.AddAsync(lecturer);

            await _context.SaveChangesAsync();

            return new Result<Lecturer>(lecturer, "Profile registration complete!");
        }

        public Task<Result<IEnumerable<Lecturer>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}