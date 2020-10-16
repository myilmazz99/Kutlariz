using System;
using System.Threading.Tasks;
using Kutlariz.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Kutlariz.WebUI.Seeds
{
    public static class IdentitySeed
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("admin"))
                await roleManager.CreateAsync(new IdentityRole("admin"));

            var admin = await userManager.FindByEmailAsync("admin@kutlariz.com");

            if (admin == null)
            {
                var newUser = await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@kutlariz.com",
                    EmailConfirmed = true,
                    FirstName = "Kutlarız",
                    LastName = "Admin",
                    Birthday = DateTime.Now
                }, "Kutlarizadmin1");

                await userManager.AddToRoleAsync(await userManager.FindByEmailAsync("admin@kutlariz.com"), "admin");
            }
        }
    }
}