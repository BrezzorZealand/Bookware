using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class ClassService : IClassService
    {
        private readonly BookwareDbContext context;

        public ClassService(BookwareDbContext context)
        {
            this.context = context;
        }

        #region Create Class
        public async Task AddClassAsync(Class? klasse)
        {
            if (klasse != null)
            {
                context.Classes.Add(klasse);
            } 
            await context.SaveChangesAsync();
        }
        #endregion

        #region Read Classes
        public async Task<IEnumerable<Class>> GetClassAsync()
        {
            return await context.Set<Class>().AsNoTracking().ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            Class? klasse = await context.Classes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClassId == id);
            return klasse!;
        }

        public async Task<Class?> GetClassDataByIdAsync(int id)
        {
            Class? cla = await context.Classes
                .Include(tc => tc.TeacherClasses)
                .ThenInclude(te => te.TeachEdu)
                .ThenInclude(es => es.EduSub)
                .ThenInclude(e => e.Edu)

                .Include(tc => tc.TeacherClasses)
                .ThenInclude(te => te.TeachEdu)
                .ThenInclude(es => es.EduSub)
                .ThenInclude(sub => sub.Subject)

                .Include(stu => stu.Students)

                .Include(cb => cb.ClassBooks)
                .ThenInclude(b => b.Book)

                .AsNoTracking()
                .FirstOrDefaultAsync();
            
            if (cla != null)
            {
                return cla!;
            }
            return null;
        }
        #endregion

        #region Update Class
        public async Task UpdateClassAsync(Class? klasse)
        {
            if (klasse != null)
            {
                context.Classes.Update(klasse);
            }
            await context.SaveChangesAsync();
        }
        #endregion

        #region Delete Class
        public async Task DeleteClassAsync(Class? klasse)
        {
            if (klasse != null)
            {
                context.Classes.Remove(klasse);
            }
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
