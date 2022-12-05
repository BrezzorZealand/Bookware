using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace Bookware.Pages.Education_Pages
{
    public class AddTeacherEduModel : PageModel
    {
        private IEducationService EduService;
        private ITeacherService TeacherService;
        public IEnumerable<EduSub>? EduSubs { get; set; }
        [BindProperty]
        public EduSub? EduSub { get; set; }
        [BindProperty]
        public Teacher? Teacher { get; set; }

        public AddTeacherEduModel(IEducationService EduService, ITeacherService TeacherService)
        {
            this.EduService = EduService;
            this.TeacherService = TeacherService;
        }

        public async Task<IActionResult> OnGetAsync(int Eid)
        {
            EduSub = await EduService.GetEduSubByIdAsync(Eid);
            Teacher = await TeacherService.GetTeacherAsync(0);
            // Get the starting subject for the dropdown.
            EduSubs = await EduService.GetEduSubsByIdAsync();
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
