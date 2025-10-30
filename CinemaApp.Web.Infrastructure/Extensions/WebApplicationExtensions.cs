using CinemaApp.Data.Seeding.Interfaces;
using CinemaApp.Web.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static class WebApplicationExtensions
{

    public static IApplicationBuilder UseManagerAccesRestriction(this IApplicationBuilder app)
    {
        app.UseMiddleware<ManagerAccesRestrictionMiddleware>();
        return app;
    }

    public static async Task<IApplicationBuilder>  SeedDefaultIdentity(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        IServiceProvider serviceProvider = scope.ServiceProvider;

        IIdentitySeeder identitySeeder = serviceProvider.GetRequiredService<IIdentitySeeder>();

       await identitySeeder
        .SeedIdentityAsync();
       

        return app;
    }
}
