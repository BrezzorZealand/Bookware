using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface ISubjectService : IGenericService<Subject>
    {
        Task<Subject?> GetDataById(int? id);
        Task<Subject?> GetByIdAsync(int? id);
        SelectList GetSelection();
    }
}
