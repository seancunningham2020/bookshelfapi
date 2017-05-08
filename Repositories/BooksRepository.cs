using System.Collections.Generic;
using System.Linq;
using bookshelfapi.Data;
using bookshelfapi.Data.Models;
using bookshelfapi.Models;

namespace bookshelfapi.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApiDataContext _context;

        public BooksRepository(ApiDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            var books = from dbBook in _context.Books
                join dbAuthor in _context.Authors on dbBook.AuthorId equals dbAuthor.Id
                select new Book {
                    Id = dbBook.Id,
                    Title = dbBook.Title,
                    Author = new Author {
                        Id = dbAuthor.Id,
                        Name = dbAuthor.Name
                    }
                };

            return books;
        }

        public Book GetById(int bookId)
        {
            var book = from dbBook in _context.Books
                join dbAuthor in _context.Authors on dbBook.AuthorId equals dbAuthor.Id
                where dbBook.Id == bookId
                select new Book {
                    Id = dbBook.Id,
                    Title = dbBook.Title,
                    Author = new Author {
                        Id = dbAuthor.Id,
                        Name = dbAuthor.Name
                    }
                };


            return book.FirstOrDefault();
        }

        public void Add(Book newBook)
        {
            _context.Books.Add(
                new DbBook {
                    Id = newBook.Id,
                    Title = newBook.Title,
                    AuthorId = newBook.Author.Id
                });
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            var existingBook = _context.Books.SingleOrDefault(x => x.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.AuthorId = book.Author.Id;
                _context.SaveChanges();
            }
        }

        public void Delete(int bookId)
        {
            var existingBook = _context.Books.SingleOrDefault(x => x.Id == bookId);
            if (existingBook != null)
            {
                _context.Books.Remove(existingBook);
                _context.SaveChanges();
            }
        }
    }
}