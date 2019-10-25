using System;
using System.Collections.Generic;

namespace CompanyDB.Models
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeesProjects = new HashSet<EmployeesProjects>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int? EducationId { get; set; }
        public int? GenderId { get; set; }

        public virtual Educations Education { get; set; }
        public virtual Genders Gender { get; set; }
        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }
    }
}
