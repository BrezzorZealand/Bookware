using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class EduSubService : GenericService<EduSub>, IEduSubService
    {
        public EduSubService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<EduSub?> GetByIdAsync(int? Eid, int? Sid)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.EduId == Eid && es.SubjectId == Sid);
        }

        public SelectList GetSelection()
        {
            IEnumerable<EduSub> eduSubs = GetAll().Include(es => es.Subject);
            List<Subject> subjects = new List<Subject>();
            foreach (var eduSub in eduSubs)
            {
                subjects.Add(eduSub.Subject);
            }
            return new SelectList(subjects, nameof(Subject.SubjectId), nameof(Subject.SubjectName));
        }
    }
}
