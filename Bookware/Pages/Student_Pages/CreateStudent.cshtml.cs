using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Bookware.Pages.Student_Pages
{
    public class CreateStudentModel : PageModel
    {

        private readonly IStudentService studentService;
        private readonly IClassService classService;

        public CreateStudentModel(IStudentService studentService, IClassService classService)
        {
            this.studentService = studentService;
            this.classService = classService;
        }

        public SelectList? Options { get; set; }

        [BindProperty]
        public Student? Student { get; set; }

        public IActionResult OnGetAsync()
        {
            Options = classService.GetSelection();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = classService.GetSelection();
                return Page();
            }

            await studentService.Create(Student);

            return RedirectToPage("AllStudents");
        }


    }
}


