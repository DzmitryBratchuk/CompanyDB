using CompanyDB.Core.Entities;
using CompanyDB.Core.Interfaces.Data;
using CompanyDB.Core.Interfaces.Services;
using CompanyDB.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyDB.Infrastructure.Services
{
    class EmployeeProjectModelCreator : IModelCreator<EmployeeProjectViewModel>
    {
        private IRepository<Employee> _employeeRepository;
        private IRepository<EmployeeProject> _employeeProjectRepository;
        private IRepository<Project> _projectRepository;


        public EmployeeProjectModelCreator(IRepository<Employee> employeeRepository,
                                           IRepository<EmployeeProject> employeeProjectRepository,
                                           IRepository<Project> projectRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeProjectRepository = employeeProjectRepository;
            _projectRepository = projectRepository;
        }

        public IEnumerable<EmployeeProjectViewModel> GetAll()
        {
            return from e in _employeeRepository.GetAll()
                   join ep in _employeeProjectRepository.GetAll() on e.Id equals ep.EmployeeId
                   join p in _projectRepository.GetAll() on ep.ProjectId equals p.Id
                   select new EmployeeProjectViewModel
                   {
                       Name = e.FirstName,
                       Surname = e.LastName,
                       ProjectTitle = p.ProjectName
                   };
        }
    }
}
