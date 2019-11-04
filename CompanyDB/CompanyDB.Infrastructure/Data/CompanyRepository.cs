using CompanyDB.Core.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyDB.Infrastructure.Data
{
    public class CompanyRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private CompanydbContext _db;

        public CompanyRepository(CompanydbContext db)
        {
            _db = db;
        }

        public void Create(TEntity entity, bool shouldSaveChanges = true)
        {
            _db.Set<TEntity>().Add(entity);
            if (shouldSaveChanges)
                this.SaveChanges();
        }

        public void Delete(object id, bool shouldSaveChanges = true)
        {
            TEntity entity = _db.Set<TEntity>().Find(id);
            if (entity != null)
                _db.Set<TEntity>().Remove(entity);
            if (shouldSaveChanges)
                this.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(object id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity, bool shouldSaveChanges = true)
        {
            _db.Entry(entity).State = EntityState.Modified;
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
