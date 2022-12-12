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
        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
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
        #endregion

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

        public async Task AddEduAsync(EduSub? eduSub, Teacher? teacher)
        {
            if (eduSub != null && teacher != null)
            {
                TeacherEdu? existingTeacherEdu = await GetTeacherEduByIdAsync(teacher.TeacherId, eduSub.EduId);

                if (!context.TeacherEdus.Contains(existingTeacherEdu))
                {
                    TeacherEdu teacherEdu = new()
                    {
                        EduSubId = eduSub.EduSubId,
                        TeacherId = teacher.TeacherId
                    };

                    context.TeacherEdus.Add(teacherEdu);
                }
            }
            await context.SaveChangesAsync();
        }

        public async Task RemoveEduAsync(TeacherEdu teacherEdu)
        {
            if (teacherEdu != null)
            {
                context.TeacherEdus.Remove(teacherEdu);
            }
            await context.SaveChangesAsync();
        }

        public async Task<TeacherEdu?> GetTeacherEduByIdAsync(int Tid, int ESid)
        {
            return await context.TeacherEdus
                .AsNoTracking()
                .FirstOrDefaultAsync(te => te.TeacherId == Tid && te.EduSubId == ESid);
        }

        public async Task<IEnumerable<TeacherEdu?>> GetTeacherEdusByIdAsync(int Tid)
        {
            return await context.TeacherEdus
                .Include(te => te.EduSub)
                .ThenInclude(es => es.Subject)
                .Where(te => te.TeacherId == Tid)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
