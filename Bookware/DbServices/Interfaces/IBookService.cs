using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IBookService
    {
        Task CreateBookAsync(Book? book);
        Task <IEnumerable<Book?>> GetBooksAsync(string filter);
        Task<IEnumerable<Book?>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book?> GetBookDataByIdAsync(int id);
        Task UpdateBookAsync(Book? book);
        Task DeleteBookAsync(Book? book);
        Task<SelectList> GetSelectionOfBooks();
    }
}