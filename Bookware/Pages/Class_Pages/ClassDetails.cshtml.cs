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
        private readonly IEducationService educationService;

        public ClassDetailsModel(IClassService service, IEducationService eduService)
        {
            this.classService = service;
            this.educationService = eduService;
        }

        public Class? Class { get; set; }
        public Education? Education { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Write a GetClassDataByIdAsync like GetEducationByIdAsync before i works in services
            Class = await classService.GetClassDataByIdAsync(id);
            Education = await educationService.GetEducationByIdAsync(id);

            if (Class is null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
