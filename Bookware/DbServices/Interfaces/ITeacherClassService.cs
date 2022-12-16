using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherClassService : IGenericService<TeacherClass>
    {
        Task<TeacherClass?> GetByIdAsync(int? TEid, int? Cid);
        IEnumerable<SelectListItem> GetSelection(int Cid);
    }
}