using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyDB.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        void Create(TEntity entity, bool shouldSaveChanges = true);
        void Update(TEntity entity, bool shouldSaveChanges = true);
        void Delete(object id, bool shouldSaveChanges = true);
        int SaveChanges();
    }
}
