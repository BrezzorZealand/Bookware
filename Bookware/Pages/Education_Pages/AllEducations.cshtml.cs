using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.Models;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Education_Pages
{
    public class AllEducationsModel : PageModel
    {
        public readonly IEducationService Service;
        public IEnumerable<Education?> Educations { get; set; }
        public Education? Education { get; set; }

        public AllEducationsModel(IEducationService Service)
        {
            this.Service = Service;
        }
        
        public async Task<IActionResult> OnGet()
        {
            Educations = await Service.GetEducationsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Education = await Service.GetEducationByIdAsync(id);

            if (Education == null)
            {
                return Page();
            }

            await Service.DeleteEducationAsync(Education);
            return RedirectToPage("AllEducations");
        }
    }
}
