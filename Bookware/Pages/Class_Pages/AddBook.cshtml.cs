using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Bookware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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

        public SelectList? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; } = new ClassBook();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            Options = await bookService.GetSelectionOfBooks();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = await bookService.GetSelectionOfBooks();
                return Page();
            }

            await classService.AddBook(ClassBook);
            return RedirectToPage("AllClasses");
        }
    }
}
