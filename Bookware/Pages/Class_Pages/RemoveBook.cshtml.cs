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

        public SelectList? Options { get; set; }

        [BindProperty]
        public ClassBook? ClassBook { get; set; } = new ClassBook();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            Options = await classService.GetSelectionOfClassBooks(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = await classService.GetSelectionOfClassBooks(ClassBook!.ClassId);
                return Page();
            }

            await classService.RemoveBook(ClassBook);
            return RedirectToPage("AllClasses");
        }
    }
}
