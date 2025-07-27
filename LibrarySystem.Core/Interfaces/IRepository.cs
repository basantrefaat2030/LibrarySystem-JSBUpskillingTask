using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //iteration only
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(int id ,T entity);
        void Update(T entity);
        void Delete(int id);
        bool Exists(int id);
    }
}
