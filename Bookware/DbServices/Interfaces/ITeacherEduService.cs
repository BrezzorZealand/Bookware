using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherEduService : IGenericService<TeacherEdu>
    {
        IEnumerable<SelectListItem> GetAllSelection();
        Task<TeacherEdu?> GetByIdAsync(int? ESid, int? Tid);
        SelectList GetSelection(int Tid);
    }
}