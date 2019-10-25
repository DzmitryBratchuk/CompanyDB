using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CompanyDB.Models;

namespace CompanyDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CompanydbContext _db;

        public HomeController(ILogger<HomeController> logger, CompanydbContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index()
        {
            var result = from e in _db.Employees
                      join ep in _db.EmployeesProjects on e.Id equals ep.EmployeeId
                      join p in _db.Projects on ep.ProjectId equals p.Id
                      select new { Name = e.FirstName, Surname = e.LastName, Project = p.ProjectName };


            foreach (var item in result)
            {

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
