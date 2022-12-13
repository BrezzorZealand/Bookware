using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Subject_Pages
{
    public class AllSubjectsModel : PageModel
    {
        private readonly ISubjectService context;

        public AllSubjectsModel (ISubjectService service)
        {
            this.context = service;
        }
        public IEnumerable<Subject?>? Subjects { get; set; }
        
        [BindProperty]
        public Subject? Subject { get; set; }

        public IActionResult OnGetAsync()
        {
            Subjects = context.GetAll();
            return Page();
        }
        public async Task <IActionResult> OnPostDeleteAsync(int id)
        {
            if (Subject == null)
            {
                return Page();
            }
            await context.Delete(await context.GetByIdAsync(id));
            return RedirectToPage("AllSubjects");
        }
    }
}
