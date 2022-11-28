using Bookware.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
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

        /* Create Method*/

        public async Task CreateBookAsync(Book? book)
        {
            if (book != null)
            {
                context.Books.Add(book);
            }
            await context.SaveChangesAsync();
        }

        /* Read Method's*/
        public async Task<IEnumerable<Book?>> GetBooksAsync(string filter)
        {
            return await context.Set<Book>()
                .Where(b => b.Title.StartsWith(filter))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Book?>> GetBooksAsync()
        {
            return await context.Set<Book>().AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            Book? book = await context.Books
                .Include(b => b.ClassBooks)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookId == id);
            return book;
        }

        public async Task<Book?> GetBookDataByIdAsync(int id)
        {
            Book? book = await context.Books
                .Include(b => b.ClassBooks)
                .ThenInclude(cb => cb.Class)
                .ThenInclude(c => c.Students)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookId == id);
            if (book != null)
            {
                return book;
            }
            return null;
        }

        /* Update Method's*/

        public async Task UpdateBookAsync(Book? book)
        {
            if (book != null)
            {
                context.Books.Update(book);
            }
            await context.SaveChangesAsync();
        }

        /* Delete Method*/

        public async Task DeleteBookAsync(Book? book)
        {
            if (book != null)
            {
                context.Books.Remove(book);
            }
            await context.SaveChangesAsync();
        }
    }
}
