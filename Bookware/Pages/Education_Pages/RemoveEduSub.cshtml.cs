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
        private readonly IEducationService educationService;

        public RemoveEduSubModel(IEducationService educationService)
        {
            this.educationService = educationService;
        }
        public SelectList? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public EduSub? EduSub { get; set; }

        public IActionResult OnGetAsync(int Eid)
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("AllEducations");
        }
    }
}
