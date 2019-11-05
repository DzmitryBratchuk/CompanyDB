using CompanyDB.Core.Interfaces.Services;
using CompanyDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Infrastructure.Services
{
    class ProjectModelCreator : IModelCreator<ProjectViewModel>
    {
        public IEnumerable<ProjectViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
