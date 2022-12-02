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

        private IEnumerable<Book>? ClassBooks { get; set; }

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await classService.AddBook(ClassBook);
            return RedirectToPage("AllClasses");
        }
    }
}
