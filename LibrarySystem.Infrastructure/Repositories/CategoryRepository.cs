using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem_JSBUpskillingTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryContext context) : base(context)
        {
        }
    }
}
