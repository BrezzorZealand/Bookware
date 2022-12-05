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
        public async Task<IActionResult> OnGetAsync()
        {            
            Students = await studentService.GetStudentsAsync();
            return Page();
        }

        public int GetSemester(Student student)
        {
            studentService.CalculateSemester(student);
            return student.Semester;
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Student = await studentService.GetStudentByIdAsync(id);

            if (Student == null)
            {
                return Page();
            }

            await studentService.DeleteStudentAsync(Student);
            return RedirectToPage("AllStudents");
        }
    }
}
