
using Microsoft.AspNetCore.DataProtection;
using CinemaApp.Data;
using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core;
using CinemaApp.Services.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;
using CinemaApp.Data.Models;

namespace CinemaApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("ConnectionString not found.");

            builder.Services.AddDbContext<CinemaAppDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            builder.Services.AddIdentity<ApplicationUser, IdentityRole> (options =>
            {
                options.SignIn.RequireConfirmedAccount = false; // »ÎË Í‡ÍÚÓ Â ‚˙‚ ÙÓÌÚÂÌ‰‡
            })
             .AddEntityFrameworkStores<CinemaAppDBContext>();


              

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // ” ¿«¬¿ÿ, ◊≈ ¡»— ¬»“ ¿“¿ ÃŒ∆≈ ƒ¿ —≈ »«œ–¿Ÿ¿ Œ“ –¿«À»◊Õ» Ã≈—“¿ ( –Œ—-—¿…“)
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // “ˇ·‚‡ ‰‡ Â Always, Á‡˘ÓÚÓ ÔÓÎÁ‚‡¯ HTTPS
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllDomainsDebug", policyBuilder =>
                {
                    policyBuilder
                    .WithOrigins("https://localhost:7180")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                     .AllowCredentials()
                     ;
                });

            });




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICinemaMovieRepository, CinemaMovieRepository>();

            builder.Services.AddScoped<IProjectionService, ProjectionService>();

            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ITicketService, TicketService>();


            // œ⁄“ ƒŒ ¬¿ÿ¿“¿ Œ¡Ÿ¿ œ¿œ ¿ —  Àﬁ◊Œ¬≈ (“ˇ·‚‡ ‰‡ Â Â‰ËÌ Ë Ò˙˘ Ë ‚ ‰‚‡Ú‡ ÔÓÂÍÚ‡!)
            string absoluteKeysPath = "C:\\Users\\cveta\\Downloads\\CinemaWeb-May-2025-Skeleton\\SharedKeys";
            var directoryInfo = new DirectoryInfo(absoluteKeysPath);

            // --- ƒŒ¡¿¬≈“≈ “Œ¬¿ —À≈ƒ AddDbContext, ÕŒ œ–≈ƒ» builder.Build() ---
            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(directoryInfo)
                .SetApplicationName("CinemaAppSharedAuthKeys");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();

            app.UseCors("AllowAllDomainsDebug");

            app.UseAuthentication();
            app.UseAuthorization();

           // app.MapIdentityApi<IdentityUser>();

            app.MapControllers();







            app.Run();
        }
    }
}
