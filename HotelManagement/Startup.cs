using Bl;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HotelManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDbContext<HotelManegementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #region Custom Services
            services.AddTransient<HotelManegementContext>();
            services.AddScoped<ISuplliersService, ClsSuppliers>();
            services.AddScoped<IGoodsService, ClsSupGoods>();
            services.AddScoped<IEmployeeService, ClsEmplyees>();
            services.AddScoped<IMeelService, ClsMeels>();
            services.AddScoped<IFoodService, ClsFood>();
            services.AddScoped<IRoomService, ClsRooms>();
            services.AddScoped<IviewSerivice, ClsRoomsView>();
            services.AddScoped<IReservationService, ClsReservations>();
            services.AddScoped<IClientService, ClsClients>();
            services.AddScoped<IOrderService, ClsOrder>();
            services.AddScoped<ICleanService, ClsRoomService>();
           
            services.AddScoped<IReportService, ClsReports>();
            #endregion
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

            }).AddEntityFrameworkStores<HotelManegementContext>().AddDefaultUI();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Users/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/Users/Login";
                //options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });


        }
    }
}
