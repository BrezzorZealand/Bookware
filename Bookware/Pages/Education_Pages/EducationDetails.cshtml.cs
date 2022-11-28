using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Education_Pages
{
    public class EducationDetailsModel : PageModel
    {
        public readonly IEducationService Service;
        public Education? Education { get; set; }

        public EducationDetailsModel(IEducationService Service)
        {
            this.Service = Service;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Education = await Service.GetEducationDataByIdAsync(id);
            
            if (Education is null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
