using System;
using System.Collections.Generic;

namespace CompanyDB.Domain.Core
{
    public partial class Education
    {
        public Education()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string InstitutionName { get; set; }
        public short GraduationYear { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
