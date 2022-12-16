using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace Bookware.Pages.Education_Pages
{
    public class AddTeacherEduModel : PageModel
    {
        private readonly IEducationService EduService;
        private readonly ITeacherService TeacherService;
        private readonly IEduSubService EduSubService;
        private readonly ITeacherEduService TeacherEduService;
        public SelectList? EduOptions { get; set; }
        public SelectList? EduSubOptions { get; set; }
        [BindProperty]
        public Teacher? Teacher { get; set; }
        [BindProperty]
        public EduSub? EduSub { get; set; }
        public TeacherEdu? TeacherEdu { get; set; }
        private int teacherId { get; set; }

        public AddTeacherEduModel(IEducationService eduService, ITeacherService teacherService, IEduSubService eduSubService, ITeacherEduService teacherEduService)
        {
            EduService = eduService;
            TeacherService = teacherService;
            EduSubService = eduSubService;
            TeacherEduService = teacherEduService;
        }

        
        public async Task<IActionResult> OnGetAsync(int Tid)
        {
            // Get the Teacher.
            teacherId = Tid;
            Teacher = await TeacherService.GetByIdAsync(Tid);
            // Get List of Educations.
            //EduOptions = EduService.GetSelection();
            // get the Starting list of Edusubs.
            EduSubOptions = EduSubService.GetSelection(0);
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            int Eid = EduSub!.EduId;
            int Sid = EduSub!.SubjectId;
            EduSub = await EduSubService.GetByIdAsync(Eid, Sid);
            TeacherEdu!.EduSubId = EduSub!.EduSubId;
            await TeacherEduService.Create(TeacherEdu);
            return RedirectToPage("AllTeachers");
        }
        
        public async void OnPostUpdatePageAsync()
        {
            Teacher = await TeacherService.GetByIdAsync(teacherId);
            //EduOptions = EduService.GetSelection();
            EduSubOptions = EduSubService.GetSelection(EduSub!.EduId);
        }
    }
}
