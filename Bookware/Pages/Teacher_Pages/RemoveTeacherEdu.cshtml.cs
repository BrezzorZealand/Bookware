using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;
using Bookware.DbServices.Interfaces;
using System.Security.Cryptography;

namespace Bookware.Pages.Education_Pages
{
    public class RemoveTeacherEduModel : PageModel
    {

        private readonly ITeacherService teacherService;
        private readonly IEduSubService eduSubService;
        private readonly ITeacherEduService teacherEduService;

        public IEnumerable<SelectListItem>? Options { get; set; }

        public RemoveTeacherEduModel(ITeacherService teacherService, IEduSubService eduSubService, ITeacherEduService teacherEduService)
        {
            this.teacherService = teacherService;
            this.eduSubService = eduSubService;
            this.teacherEduService = teacherEduService;
        }

        [BindProperty]
        public TeacherEdu? TeacherEdu { get; set; } = new TeacherEdu();
        [BindProperty]
        public Teacher? Teacher { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int Tid)
        {
            Teacher = await teacherService.GetByIdAsync(Tid!);
            Options = teacherEduService.GetSelection(Tid);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            TeacherEdu!.TeacherId = Teacher!.TeacherId;
            if (!ModelState.IsValid)
            {
                Options = teacherEduService.GetSelection(TeacherEdu!.TeacherId);
                return Page();
            }

            await teacherEduService.Delete(await teacherEduService.GetByIdAsync(TeacherEdu!.EduSubId, TeacherEdu.TeacherId));
            return RedirectToPage("AllTeachers");
        }
    }
}
