using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace Bookware.Pages.Education_Pages
{
    public class AddEduSubModel : PageModel
    {
        private IEducationService EduService;
        private ISubjectService SubService;
        public IEnumerable<Subject>? Subjects { get; set; }
        [BindProperty]
        public Education? Education { get; set; }
        [BindProperty]
        public Subject? Subject { get; set; }

        public AddEduSubModel(IEducationService EduService, ISubjectService SubService)
        {
            this.EduService = EduService;
            this.SubService = SubService;
        }


        public async Task<IActionResult> OnGetAsync(int Eid)
        {
            Education = await EduService.GetEducationByIdAsync(Eid);
            Subjects = await SubService.GetSubjectsAsync();
            // Get the starting subject for the dropdown.
            Subject = await SubService.GetSubjectByIdAsync(0);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int Sid = Subject!.SubjectId;
            Subject = await SubService.GetSubjectByIdAsync(Sid);
            await EduService.AddSubjectAsync(Education, Subject);
            return RedirectToPage("AllEducations");
        }
    }
}
