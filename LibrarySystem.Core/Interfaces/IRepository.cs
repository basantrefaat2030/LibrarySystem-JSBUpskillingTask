using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //iteration only
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(int id ,T entity);
        void Delete(int id);

        //with includes
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T GetById(int id, params Expression<Func<T, object>>[] includes);
    }
}
