using CompanyDB.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyDB.Domain.Interfaces
{
    public interface IEmployeeRepository : IDisposable
    {
        IQueryable<Employee> GetAllEmployees();
        Employee GetEmployee(object id);
        void Create(Employee employee, bool shouldSaveChanges = true);
        void Update(Employee employee, bool shouldSaveChanges = true);
        void Delete(object id, bool shouldSaveChanges = true);
        int SaveChanges();
    }
}
