using LibrarySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public T AddAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public T DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
