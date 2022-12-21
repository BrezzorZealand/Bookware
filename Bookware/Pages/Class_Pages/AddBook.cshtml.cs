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
        private readonly IClassService classService;

        public AddBookModel(IClassBookService classBookService, IBookService bookService, IClassService classService)
        {
            this.classBookService = classBookService;
            this.bookService = bookService;
            this.classService = classService;
        }

        public SelectList? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; } = new ClassBook();

        public string? ClassName { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            Class? _class = await classService.GetClassByIdAsync(id);
            ClassName = _class!.ClassName;
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

            if (await classBookService.Exists(ClassBook))
            {
                return RedirectToPage("AllClasses");
            }

            await classBookService.Create(ClassBook);
            return RedirectToPage("AllClasses");
        }
    }
}
