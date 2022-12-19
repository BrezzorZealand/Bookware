using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookware.DbServices.Services;
using static System.Reflection.Metadata.BlobBuilder;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Education_Pages
{
    public class RemoveEduSubModel : PageModel
    {
        private readonly IEduSubService eduSubService;

        public RemoveEduSubModel(IEduSubService eduSubService)
        {
            this.eduSubService = eduSubService;
        }
        public SelectList? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public EduSub? EduSub { get; set; } = new EduSub();

        public IActionResult OnGetAsync(int Eid)
        {
            EduSub!.EduId = Eid;
            Options = eduSubService.GetSelection(Eid);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = eduSubService.GetSelection(EduSub!.EduId);
                return Page();
            }

            await eduSubService.Delete(await eduSubService.GetByIdAsync(EduSub!.EduId, EduSub!.SubjectId));
            return RedirectToPage("AllEducations");
        }
    }
}
