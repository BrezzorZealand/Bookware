using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Education_Pages
{
    public class CreateEduSubModel : PageModel
    {
        private IEducationService EduService;
        private ISubjectService SubService;
        public IEnumerable<Subject> Subjects { get; set; }
        [BindProperty]
        public Education? Education { get; set; }
        [BindProperty]
        public Subject? Subject { get; set; }
        [BindProperty]
        public EduSub? EduSub { get; set; }
        public string Msg { get; set; }

        public CreateEduSubModel(IEducationService EduService, ISubjectService SubService)
        {
            this.EduService = EduService;
            this.SubService = SubService;
            Msg = "test msg";
        }


        public async Task<IActionResult> OnGetAsync(int Eid, int Sid)
        {
            Education = await EduService.GetEducationByIdAsync(Eid);
            Subject = await SubService.GetSubjectByIdAsync(Sid);
            Subjects = await SubService.GetSubjectsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(EduSub eduSub)
        {
            await EduService.CreateEduSubAsync(Education, Subject, eduSub);
            return RedirectToPage("AllEducations");
        }
    }
}
