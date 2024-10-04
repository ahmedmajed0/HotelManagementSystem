using HotelManagement.Areas.Admin.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.DataEntry.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Restaurant.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Receptionist.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.BasicUser.ToString()));
            }
        }
    }
}
