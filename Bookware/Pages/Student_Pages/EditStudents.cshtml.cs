using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Student_Pages
{
    public class EditStudentsModel : PageModel
    {
        private readonly IStudentService service;
        public EditStudentsModel(IStudentService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Student? Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await service.GetStudentsAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Student student)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await service.EditStudentAsync(Student);
            return RedirectToPage("AllStudents");
        }
        
    }
}
