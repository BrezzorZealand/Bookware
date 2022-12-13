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
        public Class? _Class { get; set; }
        public IEnumerable<Class?> ?classes { get; set; }

        public IActionResult OnGetAsync()
        {
            classes = classService.GetAll();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            _Class = await classService.GetClassByIdAsync(id);

            if (_Class == null)
            {
                return Page();
            }

            await classService.Delete(_Class);
            return RedirectToPage("AllClasses");
        }
    }
}
