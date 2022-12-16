using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Bookware.Pages.Student_Pages
{
    public class StudentClassEnrollModel : PageModel
    {
        private readonly IStudentService sService;
        private readonly IClassService classService;

        public StudentClassEnrollModel(IStudentService service, IClassService classService)
        {
            this.sService = service;
            this.classService = classService;
        }

        public SelectList? Options { get; set; }

        [BindProperty]
        public Student? Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await sService.GetByIdAsync(id);
            Options = classService.GetSelection();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await sService.Update(Student);
            return RedirectToPage("AllStudents");
        }
    }
}
