using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Eatto.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Eatto.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, params Assembly[] assembliesToScan)
        {
            services.Scan(scan => scan
            .FromAssemblies(assembliesToScan)
            .AddClasses(c => c.AssignableTo<ICategoryRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
