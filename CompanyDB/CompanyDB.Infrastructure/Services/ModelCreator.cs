using CompanyDB.Core.Interfaces.Services;
using CompanyDB.Core.Interfaces.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDB.Infrastructure.Services
{
    public class ModelCreator<TModel> : IModelCreator<TModel>
        where TModel : class, IModel
    {
        public IEnumerable<TModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
