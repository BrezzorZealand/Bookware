using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.Models;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Education_Pages
{
    public class AllEducationsModel : PageModel
    {
        public readonly IEducationService Service;
        public IEnumerable<Education?>? Educations { get; set; }
        
        [BindProperty]
        public Education? Education { get; set; }

        public AllEducationsModel(IEducationService Service)
        {
            this.Service = Service;
        }
        
        public IActionResult OnGetAsync()
        {
            Educations = Service.GetAll();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Education = await Service.GetByIdAsync(id);

            if (Education == null)
            {
                return Page();
            }

            await Service.Delete(Education);
            return RedirectToPage("AllEducations");
        }
    }
}
