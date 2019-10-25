using System;
using System.Collections.Generic;

namespace CompanyDB.Models
{
    public partial class Genders
    {
        public Genders()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
