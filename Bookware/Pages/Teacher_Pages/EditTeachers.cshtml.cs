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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Teacher = await service.GetByIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await service.Update(teacher);
            return RedirectToPage("AllTeachers");
        }
    }
}
