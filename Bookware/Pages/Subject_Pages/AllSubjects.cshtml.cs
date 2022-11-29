using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Subject_Pages
{
    public class AllSubjectsModel : PageModel
    {
        public IEnumerable<Subject>Subjects { get; set; }
        //public int SubId { get; set; }
        private ISubjectService context;

        public AllSubjectsModel (ISubjectService service)
        {
            this.context = service;
        }
        [BindProperty]
        public Subject? Subject { get; set; }

        public async Task <IActionResult>OnGetAsync(/*int subid*/)
        {
            //SubId = subid;
            Subjects = await context.GetSubjectsAsync();
            return Page();
        }
        public async Task <IActionResult> OnPostDeleteAsync(int id)
        {
            Subject = await context.GetSubjectByIdAsync(id);

            if (Subject == null)
            {
                return Page();
            }
            await context.RemoveSubjectAsync(Subject);
            return RedirectToPage("AllSubjects");
        }
    }
}
