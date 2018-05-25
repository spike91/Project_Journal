using System;
using System.Collections.Generic;

namespace Project.DataBase
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();  
    }
}
