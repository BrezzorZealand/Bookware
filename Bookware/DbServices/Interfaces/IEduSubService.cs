using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IEduSubService : IGenericService<EduSub>
    {
        IEnumerable<SelectListItem> GetAllSelection();
        Task<EduSub?> GetByIdAsync(int? Eid, int? Sid);
        SelectList GetSelection(int? Eid);
    }
}