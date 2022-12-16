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
        private readonly IClassBookService classBookService;
        private readonly IBookService bookService;

        public AddBookModel(IClassBookService classService, IBookService bookService)
        {
            this.classBookService = classService;
            this.bookService = bookService;
        }

        public SelectList? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; } = new ClassBook();

        public IActionResult OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            Options = bookService.GetSelection();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = bookService.GetSelection();
                return Page();
            }

            if (!await classBookService.Exists(ClassBook))
            {
                return RedirectToPage("AllClasses");
            }

            await classBookService.Create(ClassBook);
            return RedirectToPage("AllClasses");
        }
    }
}
