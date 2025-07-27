using LibrarySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        // Additional methods specific to Book can be added here if needed
        IEnumerable<Book> GetBooksByCategory(int categoryId);
    }
}
