using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookware.Models;
using Bookware.DbServices.Interfaces;


namespace Bookware.Pages.Class_Pages
{
    public class ClassAssignTeacherModel : PageModel
    {
        private readonly ITeacherClassService TeacherClassService;
        private readonly ITeacherEduService TeacherEduService;
        private readonly IClassService ClassService;
        public IEnumerable<SelectListItem>? TeacherEduOptions { get; set; }
        [BindProperty]
        public Class? Class { get; set; }        
        [BindProperty]
        public TeacherClass? TeacherClass { get; set; }

        public ClassAssignTeacherModel(ITeacherClassService teacherClassService, ITeacherEduService teacherEduService, IClassService classService)
        {
            TeacherClassService = teacherClassService;
            TeacherEduService = teacherEduService;
            ClassService = classService;
        }

        public async Task<IActionResult> OnGet(int Cid)
        {
            if (Cid <= 0)
            {
                return RedirectToPage("AllClasses");
            }
            TeacherEduOptions = TeacherEduService.GetAllSelection();

            Class = await ClassService.GetClassByIdAsync(Cid);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TeacherClass!.ClassId = Class!.ClassId;

            await TeacherClassService.Create(TeacherClass);

            return RedirectToPage("AllClasses");
        }
    }
}
