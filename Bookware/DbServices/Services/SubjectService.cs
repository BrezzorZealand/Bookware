using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class SubjectService : ISubjectService
    {
        BookwareDbContext context;
        public SubjectService(BookwareDbContext context)
        {
            this.context = context;
        }

        public async Task AddSubjectAsync (Subject? subject)
        {
            if (subject != null)
            {
                context.Subjects.Add(subject);
            }
            await context.SaveChangesAsync();
        }
        public async Task RemoveSubjectAsync(Subject subject)
        {
            if(subject != null)
            {
            context.Subjects.Remove(subject);
            }
            await context.SaveChangesAsync();
        }
        public async Task EditSubjectAsync(Subject subject)
        {
            if(subject != null)
            {
                context.Subjects.Update(subject);
            }
            await context.SaveChangesAsync();
        }
        public async Task <Subject?> GetSubjectByIdAsync(int id)
        {
            Subject? subject = await context.Subjects
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SubjectId == id);
            if(subject != null)
            {
                return subject;
            }
            return null;
        }
        //public async Task <IEnumerable<Subject>> GetSubjectsAsync(string filter)
        //{
        //    return await context.Set<Subject>()
        //        .Where(s => s.SubjectName.StartsWith(filter))
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
        public async Task <IEnumerable<Subject>> GetSubjectsAsync()
        {
            return await context.Set <Subject>().AsNoTracking().ToListAsync();
        }
    }
}
