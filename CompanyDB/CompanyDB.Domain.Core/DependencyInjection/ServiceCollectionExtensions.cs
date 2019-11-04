using CompanyDB.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Domain.Core.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
            where TModule : class, IModule
        {
            services.AddSingleton<TModule, TModule>();
            services.AddSingleton<IModule, TModule>(f => f.GetService<TModule>());
            services.BuildServiceProvider().GetService<TModule>().Configure(services);

            return services;
        }
    }
}
