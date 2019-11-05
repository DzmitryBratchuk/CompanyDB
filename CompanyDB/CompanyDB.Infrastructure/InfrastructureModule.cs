using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CompanyDB.Infrastructure.Data;
using CompanyDB.Core.Interfaces.SharedKernel;
using CompanyDB.Core.Interfaces.Data;
using CompanyDB.Core.Interfaces.Services;
using CompanyDB.Infrastructure.Services;
using CompanyDB.Core.Models;

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
                    options.UseSqlServer(config.GetConnectionString("CompanyDatabase"), b => b.MigrationsAssembly("CompanyDB.Infrastructure"));
                }
            });
            services.AddTransient(typeof(IRepository<>), typeof(CompanyRepository<>));
            services.AddTransient(typeof(IModelCreator<>), typeof(ModelCreator<>));
            services.AddTransient<IModelCreator<ProjectViewModel>, ProjectModelCreator>();
            services.AddTransient<IModelCreator<EmployeeProjectViewModel>, EmployeeProjectModelCreator>();
        }
    }
}
