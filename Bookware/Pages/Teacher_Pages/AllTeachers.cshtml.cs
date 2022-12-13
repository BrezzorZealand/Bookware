using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Teacher_Pages
{
    public class AllTeachersModel : PageModel
    {
        private readonly ITeacherService service;

        public AllTeachersModel(ITeacherService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Teacher? Teacher { get; set; }

        public IEnumerable<Teacher>? Teachers { get; set; }
            
        public IActionResult OnGetAsync()
        {
            Teachers = service.GetAll();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (Teacher == null)
            {
                return NotFound();
            }
            await service.Delete(await service.GetByIdAsync(id));
            return RedirectToPage("AllTeachers");
        }

    }
}
