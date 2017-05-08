using bookshelfapi.Data.Models;

namespace bookshelfapi.Data
{
    public class SeedData
    {
        public void AddSeedData(ApiDataContext context)
        {
            AddAuthors(context);
            AddBooks(context);
        }

        private void AddAuthors(ApiDataContext context)
        {
            context.Authors.Add(new DbAuthor { Id = 1, Name = "Steven King" });
            context.Authors.Add(new DbAuthor { Id = 2, Name = "Joe Hill" });
            context.Authors.Add(new DbAuthor { Id = 3, Name = "Tim Powers" });
            context.Authors.Add(new DbAuthor { Id = 4, Name = "Conn Iggulden" });
            context.Authors.Add(new DbAuthor { Id = 5, Name = "William Gibson" });

            context.SaveChanges();
        }

        private void AddBooks(ApiDataContext context)
        {
            context.Books.Add(new DbBook { Id = 1, Title = "The Green Mile", AuthorId = 1 });
            context.Books.Add(new DbBook { Id = 2, Title = "IT", AuthorId = 1 });
            context.Books.Add(new DbBook { Id = 3, Title = "The Stand", AuthorId = 1 });

            context.Books.Add(new DbBook { Id = 4, Title = "NOS4R2", AuthorId = 2 });

            context.Books.Add(new DbBook { Id = 5, Title = "The Drawing of the Dark", AuthorId = 3 });

            context.SaveChanges();
        }
    }
}