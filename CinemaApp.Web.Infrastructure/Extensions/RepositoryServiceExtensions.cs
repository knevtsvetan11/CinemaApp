using CinemaApp.Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static class RepositoryServiceExtensions
{

    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        Assembly repositoryAssembly = typeof(IWatchlistRepository).Assembly;
        Type[] repositoryInterfaces = repositoryAssembly
            .GetExportedTypes()
            .Where(t => t.IsInterface && t.Name.EndsWith("Repository"))
            .ToArray();


        foreach (var interfaceType in repositoryInterfaces)
        {
            var implementationType = repositoryAssembly
                .GetExportedTypes()
                .FirstOrDefault(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t));
            if (implementationType != null)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }

        return services;
        
    }


}
