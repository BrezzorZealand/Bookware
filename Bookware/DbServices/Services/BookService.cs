using Bookware.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.Services
{
    public class BookService : IBookService
    {
        private readonly BookwareDbContext context;

        public BookService(BookwareDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }

        public Book? GetBook(int id)
        {
            return context.Books
                .AsNoTracking()
                .FirstOrDefault(b => b.BookId == id);
        }
    }
}
