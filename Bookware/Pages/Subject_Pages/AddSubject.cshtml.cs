using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Subject_Pages
{
    public class AddSubjectModel : PageModel
    {
        private readonly ISubjectService service;
        public AddSubjectModel(ISubjectService service)
        {
            this.service = service;
        }
        [BindProperty]
        public Subject? Subject { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task <IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await service.Create(Subject!);
            return RedirectToPage("AllSubjects");
        }
    }
}
