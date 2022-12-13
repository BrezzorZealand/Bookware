using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookware.DbServices.Services;
using static System.Reflection.Metadata.BlobBuilder;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Education_Pages
{
    public class RemoveTeacherEduModel : PageModel
    {

        private readonly ITeacherService teacherService;
        
        public SelectList? EduSubs { get; set; }

        public RemoveTeacherEduModel(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [BindProperty(SupportsGet = true)]
        public TeacherEdu? TeacherEdu { get; set; }

        [BindProperty(SupportsGet = true)]
        public EduSub? EduSub { get; set; }

        [BindProperty(SupportsGet = true)]
        public Teacher? Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int Tid)
        {
            TeacherEdu!.TeacherId = Tid;
            Teacher = await teacherService.GetTeacherAsync(Tid);
            List<EduSub> eduSubs = new();
            foreach (var teacherEdu in await teacherService.GetTeacherEdusByIdAsync(Tid))
            {
                eduSubs.Add(teacherEdu!.EduSub);
            }
            EduSubs = new SelectList(eduSubs, nameof(EduSub.SubjectId), nameof(EduSub.Subject.SubjectName));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            TeacherEdu? teacherEdu = await teacherService.GetTeacherEduByIdAsync(Teacher!.TeacherId, TeacherEdu!.EduSubId);

            if (teacherEdu != null)
            {
                await teacherService.RemoveEduAsync(teacherEdu);
            }

            return RedirectToPage("AllTeachers");
        }
    }
}
