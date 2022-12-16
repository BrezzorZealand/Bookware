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

        private readonly ITeacherService TeacherService;
        private readonly IEduSubService EduSubService;
        private readonly ITeacherEduService TeacherEduService;
        
        public IEnumerable<SelectListItem>? EduSubOptions { get; set; }
        [BindProperty]
        public Teacher? Teacher { get; set; }
        [BindProperty]
        public EduSub? EduSub { get; set; } = new EduSub();
        public TeacherEdu? TeacherEdu { get; set; } = new TeacherEdu();

        public AddTeacherEduModel(ITeacherService teacherService, IEduSubService eduSubService, ITeacherEduService teacherEduService)
        {
            TeacherService = teacherService;
            EduSubService = eduSubService;
            TeacherEduService = teacherEduService;
        }

        
        public async  Task<IActionResult> OnGetAsync(int Tid)
        {
            if(Tid <= 0)
            {
                return RedirectToPage("AllTeachers");
            }
            // Get list of Educations and Subjects
            EduSubOptions = EduSubService.GetAllSelection();
            // Get the Teacher.
            Teacher = await TeacherService.GetByIdAsync(Tid);
<<<<<<< HEAD
            // Get List of Educations.
            //EduOptions = EduService.GetSelection();
            // get the Starting list of Edusubs.
            EduSubOptions = EduSubService.GetSelection(0);
=======
>>>>>>> ff92aa1ceab1184030912351d770b0ae7771e05e
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            TeacherEdu!.TeacherId = Teacher!.TeacherId;
            TeacherEdu!.EduSubId = EduSub!.EduSubId;
            if (!ModelState.IsValid)
            {
                EduSubOptions = EduSubService.GetAllSelection();
                return Page();
            }
            await TeacherEduService.Create(TeacherEdu);
            return RedirectToPage("AllTeachers");
        }
<<<<<<< HEAD
        
        public async void OnPostUpdatePageAsync()
        {
            Teacher = await TeacherService.GetByIdAsync(teacherId);
            //EduOptions = EduService.GetSelection();
            EduSubOptions = EduSubService.GetSelection(EduSub!.EduId);
        }
=======
>>>>>>> ff92aa1ceab1184030912351d770b0ae7771e05e
    }
}
