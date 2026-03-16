using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTOs;
using WebApiProject.Models;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]   
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBook(); 
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();

        
            var response = new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                IsAvailable = book.IsAvailable
            };

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateBookRequest request)
        {
          
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Isbn = request.Isbn,
                IsAvailable = true,
                CreatedAt = DateTime.UtcNow
            };

            _bookService.AddBook(book); 
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateBookRequest request)
        {
            var book = new Book
            {
                Id = id,
                Title = request.Title,
                Author = request.Author
            };

            _bookService.UpdateBook(book); 
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
             _bookService.DeleteBook(id);

            return NoContent();
        }
    }

}
