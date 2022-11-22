using Bookware.Interfaces;
using Bookware.Models;

namespace Bookware.Services
{
    public class BookService : IBookService
    {
        private readonly BookwareDbContext context;

        public BookService(BookwareDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetBøger()
        {
            return context.Books;
        }
    }
}
