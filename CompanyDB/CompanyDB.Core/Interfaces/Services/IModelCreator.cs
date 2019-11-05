using CompanyDB.Core.Interfaces.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDB.Core.Interfaces.Services
{
    public interface IModelCreator<TModel> 
        where TModel : class, IModel
    {
        IEnumerable<TModel> GetAll();

        Task<List<TModel>> GetAllAsync();
    }
}
