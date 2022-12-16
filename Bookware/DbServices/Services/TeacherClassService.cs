using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class TeacherClassService : GenericService<TeacherClass>
    {
        public TeacherClassService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<bool> Exists(TeacherClass? teacherClass)
        {
            return GetAll().Contains(await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(tc => tc.TeachEduId == teacherClass!.TeachEduId && tc.ClassId == teacherClass!.ClassId));
        }
    }
}
