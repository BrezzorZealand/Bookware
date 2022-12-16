using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Bookware.Pages.Class_Pages
{
    public class ClassEnrollStudentModel : PageModel
    {
        private readonly IClassService classService;
        private readonly IStudentService studentService;
        

        public ClassEnrollStudentModel(IStudentService sService, IClassService cService)
        {
            this.classService = cService;
            this.studentService = sService;
        }

        public SelectList? Options { get; set; }

        [BindProperty]
        public Class? Class { get; set; }

        [BindProperty]
        public Student? Student { get; set; } = new Student();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Class = await classService.GetClassByIdAsync(id);
            Options = studentService.GetSelection();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = studentService.GetSelection();
                return Page();
            }
            Student? student = await studentService.GetByIdAsync(Student!.StudentId);
            student!.ClassId = Class!.ClassId;
            await studentService.Update(student);
            return RedirectToPage("AllClasses");
        }
    }
}
