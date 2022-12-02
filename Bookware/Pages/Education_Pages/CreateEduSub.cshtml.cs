using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace Bookware.Pages.Education_Pages
{
    public class CreateEduSubModel : PageModel
    {
        private IEducationService EduService;
        private ISubjectService SubService;
        public IEnumerable<Subject>? Subjects { get; set; }
        [BindProperty]
        public Education? Education { get; set; }
        [BindProperty]
        public Subject? Subject { get; set; }
        [BindProperty]
        public EduSub? EduSub { get; set; }

        public CreateEduSubModel(IEducationService EduService, ISubjectService SubService)
        {
            this.EduService = EduService;
            this.SubService = SubService;
        }


        public async Task<IActionResult> OnGetAsync(int Eid)
        {
            Education = await EduService.GetEducationByIdAsync(Eid);
            Subjects = await SubService.GetSubjectsAsync();
            Subject = await SubService.GetSubjectByIdAsync(0);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(EduSub eduSub)
        {
            int Sid = Subject!.SubjectId;
            Subject = await SubService.GetSubjectByIdAsync(Sid);
            await EduService.CreateEduSubAsync(Education, Subject, eduSub);
            return RedirectToPage("AllEducations");
        }
    }
}
