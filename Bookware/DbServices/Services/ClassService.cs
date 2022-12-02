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
        public async Task AddClassAsync(Class? _class)
        {
            if (_class != null)
            {
                context.Classes.Add(_class);
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
            Class? _class = await context.Classes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClassId == id);
            return _class!;
        }
        #endregion

        #region Update Class
        public async Task UpdateClassAsync(Class? _class)
        {
            if (_class != null)
            {
                context.Classes.Update(_class);
            }
            await context.SaveChangesAsync();
        }
        #endregion

        #region Delete Class
        public async Task DeleteClassAsync(Class? _class)
        {
            if (_class != null)
            {
                context.Classes.Remove(_class);
            }
            await context.SaveChangesAsync();
        }
        #endregion

        #region Add Book
        public async Task AddBook(ClassBook? classBook)
        {
            if (classBook != null)
            {
                context.ClassBooks.Add(classBook);
            }
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
