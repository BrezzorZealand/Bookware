using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IEduSubService : IGenericService<EduSub>
    {
        Task<bool> Exists(EduSub? eduSub);
        IEnumerable<SelectListItem> GetAllSelection();
        Task<EduSub?> GetByIdAsync(int? Eid, int? Sid);
        SelectList GetSelection(int? Eid);
    }
}