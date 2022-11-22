using Bookware.Models;

namespace Bookware.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();

        Book? GetBook(int id);
    }
}