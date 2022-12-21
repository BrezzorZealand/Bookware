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
        private readonly IClassService classService;

        public RemoveBookModel(IClassBookService classBookService, IClassService classService)
        {
            this.classBookService = classBookService;
            this.classService = classService;
        }

        public SelectList? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; }

        public string? ClassName { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            Class? _class = await classService.GetClassByIdAsync(id);
            ClassName = _class!.ClassName;
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
