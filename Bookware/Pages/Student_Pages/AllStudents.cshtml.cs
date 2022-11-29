using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;


namespace Bookware.Pages.Student_Pages
{
    public class AllStudentsModel : PageModel
    {
        public IEnumerable<Student?> Students { get; set; }
      
        private IStudentService context;

        public AllStudentsModel(IStudentService service)
        {
            this.context = service;
        }

        [BindProperty]
        public Student? Student { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            Students = await context.GetStudentsAsync();
            return Page();
        }
       
    }
}
