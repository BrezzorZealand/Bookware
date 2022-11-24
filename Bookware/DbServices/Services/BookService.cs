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

        public void CreateBook(Book? book)
        {
            if (book != null)
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        /* Read Method's*/

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

        public Book? GetMoreBookData(int id)
        {
            return context.Books
                .Include(cb => cb.ClassBooks)
                .ThenInclude(b => b.Class)
                .ThenInclude(d => d.Students)
                .AsNoTracking()
                .FirstOrDefault(b => b.BookId == id);
        }

        /* Update Method's*/

        public void UpdateBook(Book? book)
        {
            if (book != null)
            {
                context.Books.Update(book);
                context.SaveChanges();
            }
        }

        /* Delete Method*/

        public void DeleteBook(Book? book)
        {
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }
    }
}
