using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Class_Pages
{
    public class CreateClassModel : PageModel
    {
        private readonly IClassService classService;

        public CreateClassModel(IClassService service)
        {
            this.classService = service;
        }

        [BindProperty]
        public Class? Class { get; set; }

        public IActionResult OnGetAsync()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await classService.AddClassAsync(Class);
            return RedirectToPage("AllClasses");
        }
    }
}
