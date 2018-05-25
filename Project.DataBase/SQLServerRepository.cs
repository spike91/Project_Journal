using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.DataBase
{
    public class SQLServerRepository<T>: IRepository<T> where T : class
    {
        private Context db;

        public SQLServerRepository()
        {
        }

        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity != null) db.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            T item = db.Find<T>(id);
            if (item != null) db.Set<T>().Remove(item);
        }

        public T Get(int id)
        {
            return db.Find<T>(id);
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsEnumerable<T>();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.Set<T>().Attach(entity);
        }
        
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
