using System;
using System.Collections.Generic;

namespace CompanyDB.Domain.Core
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeesProjects = new HashSet<EmployeeProject>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int? EducationId { get; set; }
        public int? GenderId { get; set; }

        public virtual Education Education { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }
}
