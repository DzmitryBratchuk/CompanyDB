using CompanyDB.Domain.Core;
using CompanyDB.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyDB.Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _db;

        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }

        public void Create(Employee employee, bool shouldSaveChanges = true)
        {
            _db.Employees.Add(employee);
            if (shouldSaveChanges)
                this.SaveChanges();
        }

        public void Delete(object id, bool shouldSaveChanges = true)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee != null)
                _db.Employees.Remove(employee);
            if (shouldSaveChanges)
                this.SaveChanges();
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return _db.Employees.AsQueryable();
        }

        public Employee GetEmployee(object id)
        {
            return _db.Employees.Find(id);
        }

        public void Update(Employee employee, bool shouldSaveChanges = true)
        {
            _db.Entry(employee).State = EntityState.Modified;
            if (shouldSaveChanges)
                this.SaveChanges();
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
