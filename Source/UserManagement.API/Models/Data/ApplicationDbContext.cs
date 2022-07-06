using Microsoft.EntityFrameworkCore;
using UserManagement.API.Enums;

namespace UserManagement.API.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<GeneratedCode>? GeneratedCodes { get; set; }
    }
}