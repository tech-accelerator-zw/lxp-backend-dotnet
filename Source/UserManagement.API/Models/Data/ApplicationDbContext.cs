using Microsoft.EntityFrameworkCore;

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
        public DbSet<Student>? Students { get; set; }
        public DbSet<Lecturer>? Lecturers { get; set; }
        public DbSet<Institute>? Institutes { get; set; }
    }
}