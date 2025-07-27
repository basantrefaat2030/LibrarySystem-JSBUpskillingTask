using LibrarySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // Additional methods specific to Category can be added here if needed
    }
}
