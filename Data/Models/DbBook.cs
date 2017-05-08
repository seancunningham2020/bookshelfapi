namespace  bookshelfapi.Data.Models
{
    public class DbBook {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }
    }
}