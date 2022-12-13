using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.Pages.Class_Pages
{
    public class RemoveBookModel : PageModel
    {
        private readonly IClassBookService classBookService;

        public RemoveBookModel(IClassBookService classService)
        {
            this.classBookService = classService;
        }

        public SelectList? Options { get; set; }

        [BindProperty]
        public ClassBook? ClassBook { get; set; } = new ClassBook();

        public IActionResult OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            Options = classBookService.GetSelection(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = classBookService.GetSelection(ClassBook!.ClassId);
                return Page();
            }

            await classBookService.Delete
                (
                    await classBookService.GetByIdAsync
                        (
                            ClassBook!.ClassId, ClassBook!.BookId
                        )
                );
            return RedirectToPage("AllClasses");
        }
    }
}
