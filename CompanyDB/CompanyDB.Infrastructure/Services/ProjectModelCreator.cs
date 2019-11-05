using CompanyDB.Core.Entities;
using CompanyDB.Core.Interfaces.Data;
using CompanyDB.Core.Interfaces.Services;
using CompanyDB.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDB.Infrastructure.Services
{
    class ProjectModelCreator : IModelCreator<ProjectViewModel>
    {
        private IRepository<Project> _projectRepository;

        public ProjectModelCreator(IRepository<Project> repository)
        {
            _projectRepository = repository;
        }

        public IEnumerable<ProjectViewModel> GetAll()
        {
            return _projectRepository.GetAll()
                .Select(p => new ProjectViewModel { ProjectTitle = p.ProjectName });
        }

        public Task<List<ProjectViewModel>> GetAllAsync()
        {
            return _projectRepository.GetAll()
                .Select(p => new ProjectViewModel { ProjectTitle = p.ProjectName }).ToListAsync();
        }
    }
}
