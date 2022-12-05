using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Bookware.Pages.Class_Pages
{
    public class ClassDetailsModel : PageModel
    {
        private readonly IClassService classService;

        public ClassDetailsModel(IClassService Service)
        {
            this.classService = Service;
        }

        public Class? Class { get; set; }
        public Education? Education { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Class = await classService.GetClassDataByIdAsync(id);

            if (Class is null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
