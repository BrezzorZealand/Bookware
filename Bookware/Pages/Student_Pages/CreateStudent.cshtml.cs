using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Student_Pages
{
    public class CreateStudentModel : PageModel
    {

        private readonly IStudentService service;

        public CreateStudentModel(IStudentService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Student? Student { get; set; }

        public IActionResult OnGetAsync()
        {
            return Page();
        }
        //private void SemesterCalculator(Object Sender)
        //{

        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await service.CreateStudentAsync(Student);

            return RedirectToPage("AllStudents");
        }


    }
}


