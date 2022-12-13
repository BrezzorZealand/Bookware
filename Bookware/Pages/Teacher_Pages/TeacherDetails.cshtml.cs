using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;

namespace Bookware.Pages.Teacher_Pages
{
    public class TeacherDetailsModel : PageModel
    {
        private readonly ITeacherService teacherService;

        public TeacherDetailsModel(ITeacherService tService)
        {
            this.teacherService = tService;
            
        }

        [BindProperty]
        public Teacher? Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int Tid)
        {
            Teacher = await teacherService.GetDataByIdAsync(Tid);

            if (Teacher is null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
