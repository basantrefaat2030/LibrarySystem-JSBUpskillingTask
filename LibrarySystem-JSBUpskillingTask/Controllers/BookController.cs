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

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAllBooks()
        {
            var AllBooks = _bookRepository.GetAll(a => a.Category);
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



                });
            }
            return Ok(Books);

        }
        [HttpGet("id")]
        public IActionResult GetBookById(int bookId)
        {
            if (bookId <= 0)
                return BadRequest("Invalid Book ID");

            var book = _bookRepository.GetById(bookId, a => a.Category);
            if (book == null)
                return NotFound("Book not found");
            var bookDto = new BookDto()
            {
                Description = book.Description,
                Author = book.Author,
                BookId = book.BookId,
                CategoryName = book.Category?.Name,
                Name = book.Name,
                Price = book.Price,
                Stock = book.Stock
                
            };


            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] AddUpdateBookDto bookData)
        {
            if(bookData.BookId <= 0)
                return BadRequest("Book ID should not be provided for new books.");

            var book = _bookRepository.GetById(bookData.BookId);
            if (book != null)
                return BadRequest("Book with this ID already exists.");
            if (ModelState.IsValid)
            {
                book = new Book()
                {
                    Name = bookData.Name,
                    Description = bookData.Description,
                    Price = bookData.Price,
                    Author = bookData.Author,
                    Stock = bookData.Stock,
                    CategoryId = bookData.CategoryId
                };
                _bookRepository.Add(book);
                return Ok(book);

            }
            return BadRequest("Invalid data provided for book creation.");

        }

        [HttpPut("id")]
        public IActionResult UpdateBook([FromBody] AddUpdateBookDto bookData)
        {
            if (bookData.BookId <= 0)
                return BadRequest("Invalid Book ID");

            var book = _bookRepository.GetById(bookData.BookId);
            if (book == null)
                return NotFound("Book not found");
            if (ModelState.IsValid)
            {
                book.Name = bookData.Name;
                book.Description = bookData.Description;
                book.Price = bookData.Price;
                book.Author = bookData.Author;
                book.Stock = bookData.Stock;
                book.CategoryId = bookData.CategoryId;
                _bookRepository.Update(book);
                return Ok(book);
            }

            return BadRequest("Invalid data provided for book update.");
        }

        [HttpDelete("id")]

        public IActionResult DeleteBook(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Book ID");
            
              Book book = _bookRepository.GetById(id);
            if (book == null)
                return NotFound("Book not found");
            
            _bookRepository.Delete(id);
            return Ok("The Book successfully");
        }
    }
}
