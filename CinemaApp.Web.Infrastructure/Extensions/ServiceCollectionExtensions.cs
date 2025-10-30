using CinemaApp.Services.Core;
using CinemaApp.Services.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        Assembly assemblyServices = typeof(IWatchlistService).Assembly;


        Type[] serviceInterfaces = assemblyServices
            .GetExportedTypes()
            .Where(t => t.IsInterface && t.Name.EndsWith("Service"))
            .ToArray();

        foreach (Type serviceInterface in serviceInterfaces)
        {
             var implementationType = assemblyServices
                .GetExportedTypes()
                .FirstOrDefault(t => t.IsClass && !t.IsAbstract && serviceInterface.IsAssignableFrom(t));
            if (implementationType != null)
            {
                serviceCollection.AddScoped(serviceInterface, implementationType);
            }
        }
            return serviceCollection;
       
    }
}
