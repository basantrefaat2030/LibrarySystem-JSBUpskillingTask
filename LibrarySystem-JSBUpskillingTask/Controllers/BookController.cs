using LibrarySystem.Core.DTOs;
using LibrarySystem.Core.Entities;
using LibrarySystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem_JSBUpskillingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository) 
        { 
            _bookRepository = bookRepository;
        }

        [Route("api/")]
        public ActionResult<IEnumerable<BookDto>> GetAllBooks()
        {
            var AllBooks = _bookRepository.GetAll();
            List<BookDto> Books = new List<BookDto>();
            foreach (var book in AllBooks)
            {
                Books.Add(new BookDto
                {

                    BookId = book.BookId,
                    Name = book.Name,
                    Description = book.Description,
                    Price = book.Price,
                    Author = book.Author,
                    Stock = book.Stock,
                    CategoryName = book.Category?.Name



                }) ;
            }
            return Ok(Books);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDto bookData)
        {
            if(ModelState.IsValid)
            {
                Book book = new()
                {
                    BookId = bookData.BookId,
                    Name = bookData.Name,
                    Description = bookData.Description,
                    Price = bookData.Price,

                    Author = bookData.Author,
                    Stock = bookData.Stock,
                    //CategoryId = _bookRepository.GetById(bookData.BookId).Category?.CategoryId

                };
            }
        }

    }
}
