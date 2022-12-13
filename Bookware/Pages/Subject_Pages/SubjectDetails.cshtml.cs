using Bookware.DbServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.Models;

namespace Bookware.Pages.Subject_Pages
{
    public class SubjectDetailsModel : PageModel
    {
        private readonly ISubjectService service;
        public SubjectDetailsModel(ISubjectService service)
        {
            this.service = service;
        }
        public Subject? Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await service.GetDataById(id);
            
            if (Subject == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
