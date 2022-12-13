using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IEducationService : IGenericService<Education>
    {
        Task<Education?> GetByIdAsync(int? id);
        Task<Education?> GetDataByIdAsync(int? id);
        SelectList? GetSelection();
    }
}