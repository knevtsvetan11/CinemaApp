using CinemaApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static class IdentityServiceExtensions
{

    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
         //services.AddDefaultIdentity<IdentityUser>(options =>
         //  {
         //      options.SignIn.RequireConfirmedAccount = false;
         //      options.Password.RequireDigit = false;
         //      options.Password.RequiredLength = 3;
         //      options.Password.RequireNonAlphanumeric = false;
         //      options.Password.RequireUppercase = false;
         //      options.Password.RequireLowercase = false;
         //  })
         //      .AddEntityFrameworkStores<CinemaAppDBContext>();


        return services;
    }
}
