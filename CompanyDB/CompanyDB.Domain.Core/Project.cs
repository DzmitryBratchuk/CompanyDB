using System;
using System.Collections.Generic;

namespace CompanyDB.Domain.Core
{
    public partial class Project
    {
        public Project()
        {
            EmployeesProjects = new HashSet<EmployeeProject>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }
}
