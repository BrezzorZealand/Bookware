using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Student_Pages
{
    public class StudentDetailsModel : PageModel
    {
         
            private readonly IStudentService service;
            public StudentDetailsModel(IStudentService service)
            {
                this.service = service;
            }
            public Student? Student { get; set; }
    

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await service.GetStudentDataById(id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
