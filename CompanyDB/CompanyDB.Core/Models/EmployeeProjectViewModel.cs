using CompanyDB.Core.Interfaces.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Core.Models
{
    public class EmployeeProjectViewModel : IModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProjectTitle { get; set; }
    }
}
