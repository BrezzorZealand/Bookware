using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Class?>> GetClassAsync()
        {
            return await context.Set<Class>().AsNoTracking().ToListAsync();
        }

        public async Task<Class?> GetClassByIdAsync(int id)
        {
            Class? _class = await context.Classes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClassId == id);
            return _class!;
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

        #region Get ClassBooksById
        public async Task<IEnumerable<ClassBook?>> GetClassBooksByIdAsync(int id)
        {
            return await context.Set<ClassBook>()
                .Where(cb => cb.ClassId == id)
                .Include(b => b.Book)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion

        #region Get ClassBookById
        public async Task<ClassBook?> GetClassBookByIdAsync(int Cid, int Bid)
        {
            return await context.ClassBooks
                .AsNoTracking()
                .FirstOrDefaultAsync(cb => cb.ClassId == Cid && cb.BookId == Bid);                
        }
        #endregion


        #region Add Book
        public async Task AddBook(ClassBook? classBook)
        {
            if (classBook != null && !context.ClassBooks.Contains(classBook))
            {
                context.ClassBooks.Add(classBook);
            }
            await context.SaveChangesAsync();
        }
        #endregion

        #region Remove Book
        public async Task RemoveBook(ClassBook? classBook)
        {
            if (classBook != null)
            {
                context.ClassBooks.Remove(classBook);
            }
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
