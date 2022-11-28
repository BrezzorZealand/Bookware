using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.Models;
using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;

namespace Bookware.Pages.Education_Pages
{
    public class AllEducationsModel : PageModel
    {
        public readonly IEducationService Service;
        public IEnumerable<Education>? Educations { get; set; }
        public Education? Education { get; set; }

        public AllEducationsModel(IEducationService Service)
        {
            this.Service = Service;
        }
        
        public void OnGet()
        {
            Educations = Service.GetEducations();
        }

        public IActionResult OnPostDelete(int id)
        {
            Education = Service.GetEducation(id);

            if (Education == null)
            {
                return Page();
            }

            Service.DeleteEducation(Education);
            return RedirectToPage("AllEducations");
        }
    }
}
