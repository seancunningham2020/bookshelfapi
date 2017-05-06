using System.Collections.Generic;
using bookshelfapi.Models;

namespace bookshelfapi.Repositories
{
    public interface IAuthorsRepository
    {
        IEnumerable<Author> GetAll();

        Author GetById(int authorId);

        void Add(Author newAuthor);

        void Update(Author author);

        void Delete(int authorId);
    }
}