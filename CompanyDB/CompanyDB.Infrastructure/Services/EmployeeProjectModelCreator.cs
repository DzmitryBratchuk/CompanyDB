using CompanyDB.Core.Interfaces.Services;
using CompanyDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Infrastructure.Services
{
    class EmployeeProjectModelCreator : IModelCreator<EmployeeProjectViewModel>
    {
        public IEnumerable<EmployeeProjectViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
