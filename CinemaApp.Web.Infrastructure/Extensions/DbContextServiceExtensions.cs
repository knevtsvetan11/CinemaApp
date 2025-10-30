using CinemaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static  class DbContextServiceExtensions
{


    public static IServiceCollection AddDatabaseServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<CinemaAppDBContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
