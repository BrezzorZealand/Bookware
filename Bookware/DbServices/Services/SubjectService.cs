using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class SubjectService : GenericService<Subject> , ISubjectService
    {
        public SubjectService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<Subject?> GetByIdAsync(int? id)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task<Subject?> GetDataById(int? id)
        {
            return await GetAll()
                .Include(s => s.EduSubs)
                .ThenInclude(e => e.Edu)
                .AsNoTracking()
                .FirstOrDefaultAsync(s=>s.SubjectId == id);
        }

        public SelectList GetSelection()
        {
            return new SelectList(GetAll(), nameof(Subject.SubjectId), nameof(Subject.SubjectName));
        }
    }
}
