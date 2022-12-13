using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Bookware.DbServices.Services
{
    public class ClassService : GenericService<Class>, IClassService
    {
        public ClassService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<Class?> GetClassByIdAsync(int? id)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClassId == id);
        }

        public async Task<Class?> GetClassDataByIdAsync(int? id)
        {
            return await GetAll()
                .Include(tc => tc.TeacherClasses)
                .ThenInclude(te => te.TeachEdu)
                .ThenInclude(es => es.EduSub)
                .ThenInclude(e => e.Edu)

                .Include(tc => tc.TeacherClasses)
                .ThenInclude(te => te.TeachEdu)
                .ThenInclude(es => es.EduSub)
                .ThenInclude(sub => sub.Subject)

                .Include(tc => tc.TeacherClasses)
                .ThenInclude(te => te.TeachEdu)
                .ThenInclude(es => es.Teacher)

                .Include(stu => stu.Students)

                .Include(cb => cb.ClassBooks)
                .ThenInclude(b => b.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.ClassId == id);
        }
    }
}
