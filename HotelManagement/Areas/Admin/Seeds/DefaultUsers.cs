using Bl;
using HotelManagement.Areas.Admin.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Seeds
{
    public static class DefaultUsers
    {

        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager)
        {
            var basicUser = new ApplicationUser()
            {
                FirstName = "Mohamed",
                LastName = "Maged",
                Email = "basic@test.com",
                EmailConfirmed = true,
                UserName = "basic@test.com",
            };


            var user = await userManager.FindByEmailAsync(basicUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(basicUser, "P@assword1234");
                await userManager.AddToRoleAsync(basicUser, Roles.BasicUser.ToString());

            }


        }



        public static async Task SeedSuperUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            var Admin = new ApplicationUser()
            {
                FirstName = "Ahmed",
                LastName = "Maged",
                Email="Admin@test.com",
                EmailConfirmed = true,
                UserName = "Admin@test.com",
            };

            var user = await userManager.FindByEmailAsync(Admin.Email);

            if (user == null)
            {
                await userManager.CreateAsync(Admin, "P@assword123");
                await userManager.AddToRolesAsync(Admin, new List<string> { Roles.Admin.ToString(),
                    Roles.DataEntry.ToString(),
                    Roles.Restaurant.ToString(),
                    Roles.Receptionist.ToString(),
                    Roles.BasicUser.ToString()
                });
            }

            await roleManager.SeedSuperClaims();

        }

        private static async Task SeedSuperClaims(this RoleManager<IdentityRole> roleManager)
        {
            var AdminRole = await roleManager.FindByNameAsync(Roles.Admin.ToString());
            await roleManager.SeedClaimsToRole(AdminRole, "Product");

        }

        private static async Task SeedClaimsToRole(this RoleManager<IdentityRole> roleManager, IdentityRole role, string modul)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GetPermissionsList(modul);

            foreach(var permission in allPermissions)
            {
                if(!allClaims.Any(c => c.Type == "Permissions" && c.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permissions", permission));
                }
            }

        }


    }
}
