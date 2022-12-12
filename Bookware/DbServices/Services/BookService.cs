using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookware.Services
{
    public class BookService : GenericService<Book>, IBookService
    {       
        public BookService(BookwareDbContext context) : base(context)
        {
        }        

        public async Task<Book?> GetByIdAsync(int? id)
        {
            return await GetAll()
                .Include(b => b.ClassBooks)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<Book?> GetDataByIdAsync(int? id)
        {
            return await GetAll()
                .Include(b => b.ClassBooks)
                .ThenInclude(cb => cb.Class)
                .ThenInclude(c => c.Students)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        /* Get a Selection of books */
        public SelectList GetSelection()
        {
            return new SelectList(GetAll().ToList(), nameof(Book.BookId), nameof(Book.Title));
        }
    }
}
