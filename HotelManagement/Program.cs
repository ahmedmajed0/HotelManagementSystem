using Bl;
using HotelManagement.Areas.Admin.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;


            #region set up users and roles
            try
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await Areas.Admin.Seeds.DefaultRoles.SeedRolesAsync(roleManager);
                await Areas.Admin.Seeds.DefaultUsers.SeedBasicUserAsync(userManager);
                await Areas.Admin.Seeds.DefaultUsers.SeedSuperUserAsync(userManager,roleManager);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            #endregion

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
