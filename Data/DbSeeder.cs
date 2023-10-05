using Microsoft.AspNetCore.Identity;
using SchoolTimeTable.Models;
using SchoolTimeTable.Constants;

namespace SchoolTimeTable.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Owner.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // create owner
            var user = new ApplicationUser
            {
                UserName = "mayowafunmi",
                Email = "akinade.mayowa@gmail.com",
                FirstName = "Mayowa",
                LastName = "Akinade",
                EmailConfirmed= true,
                PhoneNumber = "08187669362",
                PhoneNumberConfirmed = true,
            };

            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Treasure@2020");
                //await userManager.AddToRoleAsync(user, Roles.Owner.ToString());
                await userManager.AddToRolesAsync(user, new [] {Roles.Owner.ToString(), Roles.User.ToString()});
            }
        }
    }
}