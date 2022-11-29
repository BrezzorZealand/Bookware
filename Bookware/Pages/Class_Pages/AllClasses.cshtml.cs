using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookware.Pages.Class_Pages
{
    public class AllClassesModel : PageModel
    {
        private readonly IClassService classService;

        public AllClassesModel(IClassService service)
        {
            this.classService = service;
        }

        [BindProperty]
        public Class? klasse { get; set; }
        public IEnumerable<Class?> ?classes { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            classes = await classService.GetClassAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            klasse = await classService.GetClassByIdAsync(id);

            if (klasse == null)
            {
                return Page();
            }

            await classService.DeleteClassAsync(klasse);
            return RedirectToPage("AllClasses");
        }
    }
}
