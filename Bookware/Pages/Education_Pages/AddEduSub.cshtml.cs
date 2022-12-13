using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Bookware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Bookware.Pages.Education_Pages
{
    public class AddEduSubModel : PageModel
    {
        private readonly ISubjectService subService;
        private readonly IEduSubService eduSubService;

        public AddEduSubModel(ISubjectService subService, IEduSubService eduSubService)
        {
            this.subService = subService;
            this.eduSubService = eduSubService;
        }

        public SelectList? Options { get; set; }

        [BindProperty]
        public EduSub? EduSub { get; set; } = new EduSub();
        public IActionResult OnGetAsync(int Eid)
        {
            EduSub!.EduId = Eid;
            Options = subService.GetSelection();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = subService.GetSelection();
                return Page();
            }

            await eduSubService.Create(EduSub);
            return RedirectToPage("AllEducations");
        }
    }
}
