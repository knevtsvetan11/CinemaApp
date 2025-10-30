using CinemaApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace CinemaApp.Web
{

    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository;
    using CinemaApp.Data.Seeding;
    using CinemaApp.Data.Seeding.Interfaces;
    using CinemaApp.Services.Core;
    using CinemaApp.Services.Core.Interfaces;
    using CinemaApp.Services.Core.Interfaces;
    using CinemaApp.Web.Infrastructure.Extensions;
    using CinemaApp.Web.Infrastructure.Middlewares;
    using Data;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.IO;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDatabaseServices(builder.Configuration);//Created Extensions class and method correctly

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>   //TODO:How to MAKE this extensions??!
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CinemaAppDBContext>();
               

           
            builder.Services.AddRepositoryServices();//Created Extensions class and method correctly
            builder.Services.AddServices();//Created Extensions class and method correctly

            builder.Services.AddTransient<IIdentitySeeder, IdentitySeeder>();


            builder.Services.AddControllersWithViews();

            // œ⁄“ ƒŒ ¬¿ÿ¿“¿ Œ¡Ÿ¿ œ¿œ ¿ —  Àﬁ◊Œ¬≈ (“ˇ·‚‡ ‰‡ Â Â‰ËÌ Ë Ò˙˘ Ë ‚ ‰‚‡Ú‡ ÔÓÂÍÚ‡!)
            string absoluteKeysPath = "C:\\Users\\cveta\\Downloads\\CinemaWeb-May-2025-Skeleton\\SharedKeys";
            var directoryInfo = new DirectoryInfo(absoluteKeysPath);

            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(directoryInfo)
                .SetApplicationName("CinemaAppSharedAuthKeys");


             var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            await app.SeedDefaultIdentity();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseManagerAccesRestriction();// Extension method! Start before and after awlays its hard to debug 
            app.MapControllerRoute(
                 name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
