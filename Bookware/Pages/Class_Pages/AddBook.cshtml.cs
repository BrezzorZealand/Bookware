using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.Pages.Class_Pages
{
    public class AddBookModel : PageModel
    {
        private readonly IClassService classService;
        private readonly IBookService bookService;

        public AddBookModel(IClassService classService, IBookService bookService)
        {
            this.classService = classService;
            this.bookService = bookService;
        }

        public SelectList? Books { get; set; }              

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Books = new SelectList (await bookService.GetBooksAsync(), "BookId", "Title");
            ClassBook!.ClassId = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {            
            await classService.AddBook(ClassBook);
            return RedirectToPage("AllClasses");
        }
    }
}
