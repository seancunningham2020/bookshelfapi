using System.Collections.Generic;
using bookshelfapi.Models;

namespace bookshelfapi.Repositories
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAll();

        Book GetById(int bookId);

        void Add(Book newBook);

        void Update(Book book);

        void Delete(int bookId);
    }
}