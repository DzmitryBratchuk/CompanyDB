using CompanyDB.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CompanyDB.Infrastructure.Data
{
    public class InfrastructureModule : IModule
    {
        public InfrastructureModule()
        { }

        public void Configure(IServiceCollection services)
        {
            ConfigureInfrastructure(services);
        }

        public void Use()
        {
        }

        private void ConfigureInfrastructure(IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();
            
            services.AddDbContext<CompanydbContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(config.GetConnectionString("CompanyDatabase"), b => b.MigrationsAssembly("CompanyDB.Infrastructure.Data"));
                }
            });
            services.AddTransient(typeof(IRepository<>), typeof(CompanyRepository<>));
        }
    }
}
