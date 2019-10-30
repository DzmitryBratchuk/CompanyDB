﻿using System;
using System.Collections.Generic;

namespace CompanyDB.Domain.Core
{
    public partial class Gender
    {
        public Gender()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
