using LibrarySystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem_JSBUpskillingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public CategoryController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}
