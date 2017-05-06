using System.Collections.Generic;
using System.Linq;
using bookshelfapi.Data;
using bookshelfapi.Data.Models;
using bookshelfapi.Models;

namespace bookshelfapi.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly ApiDataContext _context;

        public AuthorsRepository(ApiDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            var authors = _context.Authors.Select(x => new Author {
                Id = x.Id,
                Name = x.Name
            });
            
            return authors;
        }

        public Author GetById(int authorId)
        {
            var author = _context.Authors.Where(x => x.Id == authorId)
                .Select(x => new Author {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefault();
            
            return author;
        }

        public void Add(Author newAuthor)
        {
            _context.Authors.Add(
                new DbAuthor { Id = newAuthor.Id, Name = newAuthor.Name });
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            var existingAuthor = _context.Authors.SingleOrDefault(x => x.Id == author.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int authorId)
        {
            var existingAuthor = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            if (existingAuthor != null)
            {
                _context.Authors.Remove(existingAuthor);
                _context.SaveChanges();
            }
        }
    }
}