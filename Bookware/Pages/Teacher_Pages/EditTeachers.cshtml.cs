using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Teacher_Pages
{
    public class EditTeachersModel : PageModel
    {
        private readonly ITeacherService service;

        public EditTeachersModel(ITeacherService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Teacher? Teacher { get; set; }

        public IEnumerable<Teacher>? Teachers { get; set; }

        public IActionResult OnGet()
        {
            Teachers = service.GetTeachers();
            return Page();
        }

        public IActionResult OnPostAsync(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.EditTeacher(teacher);
            return RedirectToPage("AllTeachers");
        }
    }
}
