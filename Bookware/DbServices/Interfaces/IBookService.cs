using Bookware.Models;

namespace Bookware.Interfaces
{
    public interface IBookService
    {
        void CreateBook(Book? book);
        IEnumerable<Book> GetBooks();
        Book? GetBook(int id);
        Book? GetMoreBookData(int id);
        void UpdateBook(Book? book);
        void DeleteBook(Book? book);
    }
}