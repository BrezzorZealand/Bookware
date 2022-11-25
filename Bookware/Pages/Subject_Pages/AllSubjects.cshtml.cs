using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Subject_Pages
{
    public class AllSubjectsModel : PageModel
    {
        public IEnumerable<Subject>Subjects { get; set; }
        public int SubId { get; set; }
        private ISubjectService context;

        public AllSubjectsModel (ISubjectService service)
        {
            this.context = service;
        }
        [BindProperty]
        public Subject? Subject { get; set; }

        public void OnGet(int subid)
        {
            SubId = subid;
            Subjects = context.GetSubjects();
        }
        public IActionResult OnPostDelete(int id)
        {
            Subject = context.GetSubject(id);
            if (Subject == null)
            {
                return NotFound();
            }
            context.RemoveSubject(Subject);
            return RedirectToPage("AllSubjects");
        }
    }
}
