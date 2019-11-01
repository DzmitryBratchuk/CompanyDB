using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CompanyDB.Domain.Core;
using CompanyDB.Domain.Interfaces;
using CompanyDB.Models;
using CompanyDB.Utils;

namespace CompanyDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Employee> _repository;

        public HomeController(ILogger<HomeController> logger, IRepository<Employee> repository)
        {
            
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var result = from e in _repository.GetAll()
                     select new { Name = e.FirstName, Surname = e.LastName }.ToExpando();
            //var result = from e in _db.Employees
            //          join ep in _db.EmployeesProjects on e.Id equals ep.EmployeeId
            //          join p in _db.Projects on ep.ProjectId equals p.Id
            //          select new { Name = e.FirstName, Surname = e.LastName, Project = p.ProjectName }.ToExpando();
            Task.Delay(5000);
            return View(result.ToList());
        }

        public IActionResult EmployeesProjects()
        {
           // var result = from e in _repository.GetAllEmployees()
            //             select new { Name = e.FirstName, Surname = e.LastName, Project = e.EmployeesProjects.Count }.ToExpando();

            //var result = from e in _db.Employees
            //             join ep in _db.EmployeesProjects on e.Id equals ep.EmployeeId
            //             join p in _db.Projects on ep.ProjectId equals p.Id
            //             select new { Name = e.FirstName, Surname = e.LastName, Project = p.ProjectName }.ToExpando();

            return View();
        }

        public IActionResult Projects()
        {
           // var result = from e in _repository.GetAllEmployees()
           //              select new { ProjectTitle = e.Education }.ToExpando();

            //var result = _db.Projects.Select(p => new { ProjectTitle = p.ProjectName }.ToExpando());

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
