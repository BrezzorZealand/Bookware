using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;


namespace Bookware.Pages.Student_Pages
{
    public class AllStudentsModel : PageModel
    {      
        private readonly IStudentService studentService;

        public AllStudentsModel(IStudentService service)
        {
            studentService = service;
        }

        [BindProperty]
        public Student? Student { get; set; }
        public IEnumerable<Student?>? Students { get; set; }
        public IActionResult OnGetAsync()
        {            
            Students = studentService.GetAll();
            return Page();
        }

        public int GetSemester(Student? student)
        {
            return studentService.CalculateSemester(student);
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (Student == null)
            {
                return Page();
            }

            await studentService.Delete(await studentService.GetByIdAsync(id));
            return RedirectToPage("AllStudents");
        }
    }
}
