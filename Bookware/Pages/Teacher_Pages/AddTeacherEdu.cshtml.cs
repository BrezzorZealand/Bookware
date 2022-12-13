using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace Bookware.Pages.Education_Pages
{
    public class AddTeacherEduModel : PageModel
    {
        private IEducationService EduService;
        private ITeacherService TeacherService;
        public IEnumerable<EduSub?>? EduSubs { get; set; }
        public IEnumerable<Education?> Educations { get; set; }
        [BindProperty]
        public EduSub? EduSub { get; set; }
        [BindProperty]
        public Teacher? Teacher { get; set; }
        [BindProperty]
        public Education? Education { get; set; }

        public AddTeacherEduModel(IEducationService EduService, ITeacherService TeacherService)
        {
            this.EduService = EduService;
            this.TeacherService = TeacherService;
        }

        //public async Task<IActionResult> OnGetAsync(int Tid)
        //{
        //    // Get the Teacher.
        //    Teacher = await TeacherService.GetTeacherAsync(Tid);
        //    // Get List of Educations.
        //    Educations = await EduService.GetEducationsAsync();
        //    // Get the starting Education for the dropdown.
        //    Education = Educations.First();
        //    // get the Starting list of Edusubs.
        //    EduSubs = await EduService.GetEduSubsByIdAsync(Education!.EduId);
        //    return Page();
        //}

        //public async Task<IActionResult> OnPostCreateAsync()
        //{
        //    int Eid = Education!.EduId;
        //    int Sid = EduSub!.SubjectId;
        //    EduSub = await EduService.GetEduSubByIdAsync(Eid, Sid);
        //    await TeacherService.AddEduAsync(EduSub, Teacher);
        //    return RedirectToPage("AllTeachers");
        //}

        //public async Task<IActionResult> OnPostUpdateAsync()
        //{
        //    int Eid = Education!.EduId;
        //    EduSubs = await EduService.GetEduSubsByIdAsync(Eid);
        //    return new EmptyResult();
        //}
    }
}
