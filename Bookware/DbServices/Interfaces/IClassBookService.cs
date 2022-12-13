using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IClassBookService : IGenericService<ClassBook>
    {
        Task<ClassBook?> GetByIdAsync(int? Cid, int? Bid);
        SelectList GetSelection(int? id);
    }
}