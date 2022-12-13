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
        
        public IEnumerable<TeacherClass?> teacherClasses { get; set; }

        public TeacherDetailsModel(ITeacherService tService)
        {
            this.teacherService = tService;
            
        }

        [BindProperty]
        public Teacher? Teacher { get; set; }
        public TeacherClass? TeacherClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int Tid)
        {
            Teacher = await teacherService.GetTeacherDataByIdAsync(Tid);
            teacherClasses = await teacherService.GetTeacherClassesByIdAsync(Tid);

            if (Teacher is null && teacherClasses is null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
