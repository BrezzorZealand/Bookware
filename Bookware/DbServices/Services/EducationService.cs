using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;

namespace Bookware.DbServices.Services
{
    public class EducationService : IEducationService
    {
        private readonly BookwareDbContext context;

        public EducationService(BookwareDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Education?>> GetEducationsAsync()
        {
            return await context.Set<Education>().AsNoTracking().ToListAsync();
        }

        public async Task<Education?> GetEducationByIdAsync(int id)
        {
            Education? education = await context.Educations
                .Include(es => es.EduSubs)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EduId == id);
            return education;
        }

        public async Task EditEducationAsync(Education? education)
        {
            if (education != null)
            {
                context.Educations.Update(education);

            }
            await context.SaveChangesAsync();
        }

        public async Task CreateEducationAsync(Education? education)
        {
            if (education != null)
            {
                context.Educations.Add(education);
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteEducationAsync(Education? education)
        {
            if (education != null)
            {
                context.Educations.Remove(education);

            }
            await context.SaveChangesAsync();
        }

        public async Task<Education?> GetEducationDataByIdAsync(int id)
        {
            Education? edu = await context.Educations
                .Include(es => es.EduSubs)
                .ThenInclude(s => s.Subject)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EduId == id);
            if (edu != null)
            {
                return edu!;
            }
            return null;
        }

        public async Task AddSubjectAsync(Education? education, Subject? subject)
        {
            if (education != null && subject != null)
            {
                EduSub? existingEduSub = await GetEduSubByIdAsync(education!.EduId, subject!.SubjectId);

                if (!context.EduSubs.Contains(existingEduSub))
                {
                    EduSub eduSub = new()
                    {
                        EduId = education.EduId,
                        SubjectId = subject.SubjectId
                    };
                    
                    context.EduSubs.Add(eduSub);
                }
            }
            await context.SaveChangesAsync();
        }

        public async Task RemoveSubjectAsync(EduSub eduSub)
        {
            if (eduSub != null)
            {
                context.EduSubs.Remove(eduSub);
            }
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EduSub?>> GetEduSubsByIdAsync(int Eid)
        {
            return await context.Set<EduSub>()
                .Where(es => es.EduId == Eid)
                .Include(s => s.Subject)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EduSub?> GetEduSubByIdAsync(int Eid, int Sid)
        {
            return await context.EduSubs
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.EduId == Eid && es.SubjectId == Sid);
        }
    }
}
