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
            context = service;
        }

        public void OnGet(int subid)
        {
            SubId = subid;
            Subjects = context.GetSubjects();
        }
    }
}
