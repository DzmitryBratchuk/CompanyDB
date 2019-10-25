using System;
using System.Collections.Generic;

namespace CompanyDB.Models
{
    public partial class Educations
    {
        public Educations()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string InstitutionName { get; set; }
        public short GraduationYear { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
