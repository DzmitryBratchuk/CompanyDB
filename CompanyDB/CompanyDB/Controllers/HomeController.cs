using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CompanyDB.Utils;
using CompanyDB.Core.Entities;
using CompanyDB.Core.Interfaces.Data;
using CompanyDB.Core.Models;
using CompanyDB.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EmployeesProjects()
        {
            IModelCreator<EmployeeProjectViewModel> creator = HttpContext.RequestServices.GetService<IModelCreator<EmployeeProjectViewModel>>();

            var result = await creator.GetAllAsync();

            return View(result);
        }

        public async Task<IActionResult> Projects()
        {
            IModelCreator<ProjectViewModel> creator = HttpContext.RequestServices.GetService<IModelCreator<ProjectViewModel>>();

            var result = await creator.GetAllAsync();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
