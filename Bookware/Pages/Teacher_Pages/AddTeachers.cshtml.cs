using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Teacher_Pages
{
    public class AddTeachersModel : PageModel
    {

        private readonly ITeacherService teacherService;

        public AddTeachersModel(ITeacherService service)
        {
            this.teacherService = service;
        }

        [BindProperty]
        public Teacher? Teacher { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAsync(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            teacherService.AddTeacher(teacher);
            return RedirectToPage("AllTeachers");
        }
    }
}
