using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Core.Interfaces.SharedKernel
{
    public interface IModule
    {
        void Configure(IServiceCollection services);

        void Use();
    }
}
