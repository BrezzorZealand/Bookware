using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Class_Pages
{
    public class UpdateClassModel : PageModel
    {
        private readonly IClassService classService;

        public UpdateClassModel(IClassService service)
        {
            this.classService = service;
        }

        [BindProperty]
        public Class? _Class { get; set; }

        public async Task <IActionResult> OnGetAsync(int id)
        {
            _Class = await classService.GetClassByIdAsync(id);
            return Page();
        }

        public async Task <IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await classService.UpdateClassAsync(_Class);
            return RedirectToPage("AllClasses");
        }
    }
}
