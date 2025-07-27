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
        IEnumerable<T> GetAllAsync();
        T GetByIdAsync(int id);
        T AddAsync(int id ,T entity);
        T UpdateAsync(T entity);
        T DeleteAsync(int id);
        bool ExistsAsync(int id);
    }
}
