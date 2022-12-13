using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IBookService: IGenericService<Book>
    {
        Task<Book?> GetByIdAsync(int? id);
        Task<Book?> GetDataByIdAsync(int? id);
        SelectList GetSelection();
    }
}