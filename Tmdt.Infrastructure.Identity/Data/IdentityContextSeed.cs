using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tmdt.Domain.Enums;
using Tmdt.Infrastructure.Identity.Entities;

namespace Tmdt.Infrastructure.Identity.Data
{
    public static class IdentityContextSeed
    {
        public static async Task SeedAsync(IServiceProvider service)
        {
            var context = service.GetRequiredService<IdentityContext>();
            await context.Database.EnsureCreatedAsync();


            var userManager = service.GetRequiredService<UserManager<User>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            }

            if (!userManager.Users.Any())
            {
                var admin = new User
                {
                    UserName = "admin",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Email = "admin@email.com",
                    PhoneNumber = "0123456789",
                    FullName = "Admin"
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, Roles.Admin);

                var user = new User
                {
                    UserName = "user",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Email = "user@email.com",
                    PhoneNumber = "0123456789",
                    FullName = "User"
                };

                await userManager.CreateAsync(user, "User@123");
                await userManager.AddToRoleAsync(user, Roles.User);
            }
        }
    }
}
