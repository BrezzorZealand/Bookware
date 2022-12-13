using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class TeacherService : GenericService<Teacher> , ITeacherService
    {
        public TeacherService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<Teacher?> GetByIdAsync(int? id)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TeacherId == id );
        }
        
        public async Task<Teacher?> GetDataByIdAsync(int? id)
        {
            return await GetAll()
                .Include(t => t.TeacherEdus)
                .ThenInclude(te => te.EduSub.Subject)
                .Include(t => t.TeacherEdus)
                .ThenInclude(te => te.TeacherClasses)
                .ThenInclude(tc => tc.Class)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TeacherId == id);
        }        
    }
}
