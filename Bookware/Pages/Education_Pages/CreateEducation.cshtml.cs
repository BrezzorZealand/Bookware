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

        public async Task<IActionResult> OnPostAsync(Education education)
        {
            await Service.CreateEducationAsync(education);
            return RedirectToPage("AllEducations");
        }
    }
}
