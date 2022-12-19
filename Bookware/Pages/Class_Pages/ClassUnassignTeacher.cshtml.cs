using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bookware.Models;
using Bookware.DbServices.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace Bookware.Pages.Class_Pages
{
    public class ClassUnassignTeacherModel : PageModel
    {
        private readonly ITeacherClassService TeacherClassService;
        private readonly IClassService ClassService;
        

        public ClassUnassignTeacherModel(ITeacherClassService teacherClassService, IClassService classService)
        {
            TeacherClassService = teacherClassService;
            ClassService = classService;
        }

        public IEnumerable<SelectListItem>? Options { get; set; }
        [BindProperty]
        public Class? Class { get; set; }
        [BindProperty(SupportsGet = true)]
        public TeacherClass? TeacherClass { get; set; }


        public async Task<IActionResult> OnGetAsync(int Cid)
        {
            Class = await ClassService.GetClassByIdAsync(Cid);
            TeacherClass!.ClassId = Cid;
            Options = TeacherClassService.GetSelection(Cid);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = TeacherClassService.GetSelection(TeacherClass!.ClassId);
            }

            await TeacherClassService.Delete(await TeacherClassService.GetByIdAsync(TeacherClass!.TeachEduId, TeacherClass.ClassId));
            return RedirectToPage("AllClasses");
        }
    }
}
