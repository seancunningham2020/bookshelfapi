using bookshelfapi.Data.Models;

namespace bookshelfapi.Data
{
    public class SeedData
    {
        public void AddSeedData(ApiDataContext context)
        {
            AddAuthors(context);
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
    }
}