using UserManagement.API.Enums;

namespace UserManagement.API.Models.Data
{
    public class AppDbInitializer
    {
        public static void Seed(WebApplication app)
        {
            using var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            if (!context!.Accounts!.Any())
            {
                context.Accounts!.Add(new Account
                {
                    Email = "admin@admin.com",
                    RoleId = 1,
                    UserName = "admin",
                    FirstName = "Super",
                    LastName = "Admin",
                    Password = "$ju!137$V1$10000$Y6WVORfADjluJmwF0/bS0Vv9McwCQdj/h6HYf/omtIqBIchy",
                    Status = Status.Verified,
                    DateCreated = DateTime.Now,
                    PhoneNumber = string.Empty
                });

                context.SaveChanges();
            }
        }
    }
}