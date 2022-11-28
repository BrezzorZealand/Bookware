using Bookware.DbServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.Models;

namespace Bookware.Pages.Subject_Pages
{
    public class EditSubjectModel : PageModel
    {
        private readonly ISubjectService service;

        public EditSubjectModel(ISubjectService service)
        {
            this.service = service;
        }
        [BindProperty]
        public Subject? Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await service.GetSubjectByIdAsync(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.EditSubjectAsync(Subject);
            return RedirectToPage("AllSubjects");
        }

    }
}
