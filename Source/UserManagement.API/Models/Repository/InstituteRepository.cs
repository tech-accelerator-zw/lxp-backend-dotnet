using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using UserManagement.API.Enums;
using UserManagement.API.Models.Data;

namespace UserManagement.API.Models.Repository
{
    public class InstituteRepository : IInstituteRepository
    {
        private readonly ApplicationDbContext _context;

        public InstituteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Institute>> AddAsync(InstituteRequest request)
        {
            var account = await _context.Accounts!.Where(x => x.Id == request.UserId).FirstOrDefaultAsync();
            if (account == null) return new Result<Institute>(false, "User account not found!");

            var code = await _context.GeneratedCodes!.Where(x => x.UserEmail == account.Email && x.Code == request.Otp).FirstOrDefaultAsync();
            if (code == null) return new Result<Institute>(false, "Invalid OTP provided!");

            account.Status = AccountStatus.Verified;
            account.DateModified = DateTime.Now;

            _context.Accounts!.Update(account);

            var institute = new Institute
            {
                RegisteredName = request.RegisteredName,
                LogoUrl = request.LogoUrl,
                UserId = request.UserId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            await _context.Institutes!.AddAsync(institute);

            await _context.SaveChangesAsync();

            return new Result<Institute>(institute, "Profile registration complete!");
        }

        public Task<Result<IEnumerable<Institute>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}