using bookshelfapi.Models;
using bookshelfapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookshelfapi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        
        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            var books = _booksRepository.GetAll();
            return Ok(books);
        }

        [HttpGet("{bookId}", Name="GetBookById")]
        public IActionResult GetById(int bookId)
        {
            var book = _booksRepository.GetById(bookId);
            if (book == null)
            {
                return NotFound();
            }

            return new ObjectResult(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            _booksRepository.Add(newBook);

            return CreatedAtRoute("GetBookById", new { bookId = newBook.Id }, newBook);
        }

        [HttpPut("{bookId}")]
        public IActionResult Update(int bookId, [FromBody] Book book)
        {
            if (book == null || book.Id != bookId)
            {
                return BadRequest();
            }

            var bookToUpdate = _booksRepository.GetById(bookId);
            if (bookToUpdate == null)
            {
                return NotFound();
            }

            _booksRepository.Update(book);

            return new NoContentResult();
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            var bookToDelete = _booksRepository.GetById(bookId);
            if (bookToDelete == null)
            {
                return NotFound();
            }

            _booksRepository.Delete(bookId);

            return new NoContentResult();
        }
    }
}