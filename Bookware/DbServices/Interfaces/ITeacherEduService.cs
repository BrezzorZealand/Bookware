using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherEduService : IGenericService<TeacherEdu>
    {
        Task<bool> Exists(TeacherEdu? teacherEdu);
        IEnumerable<SelectListItem> GetAllSelection();
        Task<TeacherEdu?> GetByIdAsync(int? ESid, int? Tid);
        IEnumerable<SelectListItem> GetSelection(int Tid);
    }
}