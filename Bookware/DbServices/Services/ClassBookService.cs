using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class ClassBookService : GenericService<ClassBook>, IClassBookService
    {
        public ClassBookService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<ClassBook?> GetByIdAsync(int? Cid, int? Bid)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(cb => cb.ClassId == Cid && cb.BookId == Bid);
        }

        public SelectList GetSelection(int? id)
        {
            IEnumerable<ClassBook> classBooks = GetAll().Where(cb => cb.ClassId == id).Include(cb => cb.Book); 
            List<Book> books = new List<Book>();
            foreach (var classBook in classBooks)
            {
                books.Add(classBook.Book);
            }
            return new SelectList(books, nameof(Book.BookId), nameof(Book.Title));
        }
        public IEnumerable<SelectListItem> GetClassBookSelection(int? id)
        {
            IEnumerable<ClassBook> classBooks = GetAll().Where(cb => cb.ClassId == id).Include(cb => cb.Book);
            IEnumerable<SelectListItem> selectListItems = from classBook in classBooks
                                                          select new SelectListItem
                                                          {
                                                              Text = classBook.Book.Title,
                                                              Value = classBook.CbId.ToString()
                                                          };
            return selectListItems;
        }

        public async Task<bool> Exists(ClassBook? classBook)
        {
            return GetAll().Contains(await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(cb => cb.ClassId == classBook!.ClassId && cb.BookId == classBook!.BookId));
        }
    }
}
