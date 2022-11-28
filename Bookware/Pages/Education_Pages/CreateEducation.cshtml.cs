using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Education_Pages
{
    public class CreateEducationModel : PageModel
    {
        private readonly IEducationService Service;
        public Education? Education { get; set; }

        public CreateEducationModel(IEducationService Service)
        {
            this.Service = Service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(Education education)
        {
            Service.CreateEducation(education);
            return RedirectToPage("AllEducations");
        }
    }
}
