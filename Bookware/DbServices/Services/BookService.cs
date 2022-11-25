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
                .FirstOrDefault(b => b.BookId == id);
        }

        public Book? GetMoreBookData(int id)
        {
            return context.Books
                .Include(cb => cb.ClassBooks)
                .ThenInclude(b => b.Class)
                .ThenInclude(d => d.Students)
                .FirstOrDefault(b => b.BookId == id);
        }

        /* Update Method's*/

        public void UpdateBook(Book? updatedBook)
        {
            if (updatedBook != null)
            {
                Book? book = GetBook(updatedBook!.BookId);

                if (book != null)
                {
                    book.BookId = updatedBook.BookId;
                    book.Title = updatedBook.Title;
                    book.Author = updatedBook.Author;
                    book.Year = updatedBook.Year;
                    book.Isbn = updatedBook.Isbn;

                    context.Update(book);
                    context.SaveChanges();
                }
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
