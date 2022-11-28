using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
