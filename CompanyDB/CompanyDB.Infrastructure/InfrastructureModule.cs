using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CompanyDB.Infrastructure.Data;
using CompanyDB.Core.Interfaces.SharedKernel;
using CompanyDB.Core.Interfaces.Data;

namespace CompanyDB.Infrastructure
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
