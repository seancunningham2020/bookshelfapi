using bookshelfapi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace bookshelfapi.Data
{
    public class ApiDataContext : DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options)
            : base (options)
        {
        }
        
        public DbSet<DbAuthor> Authors { get; set; }
    }
}