using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace Bookware.Pages.Class_Pages
{
    public class ClassDetailsModel : PageModel
    {
        private readonly IClassService classService;
        public ClassDetailsModel(IClassService service)
        {
            this.classService = service;
        }

        public Class? Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            // Write a GetClassDataByIdAsync like GetEducationByIdAsync before i works in services
            Class = await classService.GetClassDataByIdAsync(id);

            if (Class is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
