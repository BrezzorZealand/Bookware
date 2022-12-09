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
        private readonly IClassService classService;

        public TeacherDetailsModel(ITeacherService tService, IClassService cService)
        {
            this.teacherService = tService;
            this.classService = cService;
        }

        public Teacher? Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Teacher = await teacherService.GetTeacherDataByIdAsync(id);

            if (Teacher is null)
            {
                return NotFound();
            }
            return Page(); 
        }
    }
}
