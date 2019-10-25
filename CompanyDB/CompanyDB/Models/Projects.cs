using System;
using System.Collections.Generic;

namespace CompanyDB.Models
{
    public partial class Projects
    {
        public Projects()
        {
            EmployeesProjects = new HashSet<EmployeesProjects>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }
    }
}
