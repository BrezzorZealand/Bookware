using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Education_Pages
{
    public class UpdateEducationModel : PageModel
    {
        readonly IEducationService Service;
        public Education? Education { get; set; }

        public UpdateEducationModel(IEducationService Service)
        {
            this.Service = Service;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Education = await Service.GetByIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Education? education)
        {
            await Service.Update(education);
            return RedirectToPage("AllEducations");
        }
    }
}
