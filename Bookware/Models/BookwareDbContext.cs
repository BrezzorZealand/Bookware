using Microsoft.EntityFrameworkCore;

namespace Bookware.Models
{
    public class BookwareDbContext: DbContext
    {
        public BookwareDbContext()
        {
        }

        public BookwareDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
