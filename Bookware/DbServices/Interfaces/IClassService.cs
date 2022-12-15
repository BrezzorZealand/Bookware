using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IClassService : IGenericService<Class>
    {
        Task <Class?> GetClassByIdAsync(int? id);
        Task <Class?> GetClassDataByIdAsync(int? id);
        SelectList GetSelection();
    }
}
