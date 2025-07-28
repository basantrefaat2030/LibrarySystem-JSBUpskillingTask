using LibrarySystem.Core.Interfaces;
using LibrarySystem_JSBUpskillingTask.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryContext _context;

        public BaseRepository(LibraryContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
             _context.Set<T>().Add(entity);
             _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity =  GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            };
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return  query.ToList();
        }

        public T GetById(int id)
        {
            return  _context.Set<T>().Find(id);
        }

        public T GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return  query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);

        }

        public void Update(int id ,T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
             _context.SaveChanges();
        }
    }
}
