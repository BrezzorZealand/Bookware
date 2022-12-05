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
        public SelectList? Subjects { get; set; }

        public RemoveEduSubModel(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        [BindProperty(SupportsGet = true)]
        public EduSub? EduSub { get; set; }

        public async Task<IActionResult> OnGetAsync(int Eid)
        {
            EduSub!.EduId = Eid;
            List<Subject> subjects = new();
            foreach (var eduSub in await educationService.GetEduSubsByIdAsync(Eid))
            {
                subjects.Add(eduSub!.Subject);
            }
            Subjects = new SelectList(subjects, "SubjectId", "SubjectName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            EduSub? eduSub = await educationService.GetEduSubByIdAsync(EduSub!.EduId, EduSub!.SubjectId);

            if (eduSub != null)
            {
                await educationService.RemoveSubjectAsync(eduSub);
            }

            return RedirectToPage("AllEducations");
        }
    }
}
