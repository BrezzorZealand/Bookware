using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.Pages.Class_Pages
{
    public class RemoveBookModel : PageModel
    {
        private readonly IClassService classService;

        public RemoveBookModel(IClassService classService)
        {
            this.classService = classService;
        }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            List<Book> books = new List<Book>();
            foreach (var item in await classService.GetClassBooksByIdAsync(id))
            {
                books.Add(item!.Book);
            }
            Books = new SelectList(books, "BookId", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ClassBook? classBook = await classService.GetClassBookByIdAsync(ClassBook!.ClassId, ClassBook!.BookId);
            
            if (classBook != null)
            {
                await classService.RemoveBook(classBook);
            }
            
            return RedirectToPage("AllClasses");
        }
    }
}
