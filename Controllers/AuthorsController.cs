using bookshelfapi.Models;
using bookshelfapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bookshelfapi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private IAuthorsRepository _authorsRepository;

        public AuthorsController(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }
        
        // GET api/authors
        [HttpGet]
        public IActionResult Get()
        {
            var authors = _authorsRepository.GetAll();
            return Ok(authors);
        }

        [HttpGet("{authorId}", Name="GetAuthorById")]
        public IActionResult GetById(int authorId)
        {
            var author = _authorsRepository.GetById(authorId);
            if (author == null)
            {
                return NotFound();
            }

            return new ObjectResult(author);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Author newAuthor)
        {
            if (newAuthor == null)
            {
                return BadRequest();
            }

            _authorsRepository.Add(newAuthor);

            return CreatedAtRoute("GetAuthorById", new { authorId = newAuthor.Id }, newAuthor);
        }

        [HttpPut("{authorId}")]
        public IActionResult Update(int authorId, [FromBody] Author author)
        {
            if (author == null || author.Id != authorId)
            {
                return BadRequest();
            }

            var authorToUpdate = _authorsRepository.GetById(authorId);
            if (authorToUpdate == null)
            {
                return NotFound();
            }

            _authorsRepository.Update(author);

            return new NoContentResult();
        }

        [HttpDelete("{authorId}")]
        public IActionResult Delete(int authorId)
        {
            var authorToDelete = _authorsRepository.GetById(authorId);
            if (authorToDelete == null)
            {
                return NotFound();
            }

            _authorsRepository.Delete(authorId);

            return new NoContentResult();
        }
    }
}