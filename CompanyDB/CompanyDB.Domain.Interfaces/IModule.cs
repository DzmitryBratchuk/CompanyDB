using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Domain.Interfaces
{
    public interface IModule
    {
        void Configure(IServiceCollection services);

        void Use();
    }
}
