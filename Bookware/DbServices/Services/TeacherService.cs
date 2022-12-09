using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly BookwareDbContext context;

        public TeacherService(BookwareDbContext context)
        {
            this.context = context;
        }

        #region Create Teacher Method
        public async Task AddTeacherAsync(Teacher? teacher)
        {
            if (teacher != null)
            {
                context.Teachers.Add(teacher);
                
            }
            await context.SaveChangesAsync();
        }
        #endregion

        #region Read Teacher Method
        public async Task<IEnumerable<Teacher?>> GetTeachersAsync()
        {
            return await context.Set<Teacher>().AsNoTracking().ToListAsync();
        }

        public async Task<Teacher?> GetTeacherAsync(int id)
        {
            Teacher? teacher = await context.Teachers
                .AsNoTracking().
                FirstOrDefaultAsync(t => t.TeacherId == id );
            return teacher;
        }

        public async Task<Teacher?> GetTeacherDataByIdAsync(int id)
        {
            Teacher? teacher = await context.Teachers
                // Class Subjects 

                .Include(tes => tes.TeacherEdus)
                .ThenInclude(es => es.EduSub)
                .ThenInclude(s => s.Subject)

                .AsNoTracking().
                FirstOrDefaultAsync(t => t.TeacherId == id);

            if (teacher !=null)
            {
                return teacher; 
            }
            return null;
        }
        #endregion

        public async Task<IEnumerable<TeacherClass>> GetTeacherClassesByIdAsync(int id)
        {
            return await context.Set<TeacherClass>()
                .Where(tc => tc.TeachClassId == id)
                .Include(c => c.ClassId)
                .AsNoTracking()
                .ToListAsync();
        }



        //public async Task<TeacherClass> GetTeacherClassByIdAsync(int TcId)
        //{
        //    return await context.TeacherEdus
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(tc => tc.TeacherClasses == TcId);
        //}

        #region Update Teacher Method
        public async Task EditTeacherAsync(Teacher? teacher)
        {
            if (teacher != null)
            {
                    context.Teachers.Update(teacher);
                    
            }
            await context.SaveChangesAsync();
        }
        #endregion

        #region Delete Teacher Method
        public async Task RemoveTeacherAsync(Teacher? teacher)
        {
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                
            }
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
