using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Education_Pages
{
    public class UpdateEducationModel : PageModel
    {
        IEducationService Service;
        public Education? Education { get; set; }

        public UpdateEducationModel(IEducationService Service)
        {
            this.Service = Service;
        }

        public IActionResult OnGet(int id)
        {
            Education = Service.GetEducation(id);
            return Page();
        }

        public Education? GetEducation()
        {
            return Education;
        }

        public IActionResult OnPost(Education? education)
        {
            Service.EditEducation(education);
            return RedirectToPage("AllEducations");
        }
    }
}
