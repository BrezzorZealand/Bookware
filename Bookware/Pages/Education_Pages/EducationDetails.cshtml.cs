using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Education_Pages
{
    public class EducationDetailsModel : PageModel
    {
        public readonly IEducationService Service;
        public Education? Education { get; set; }

        public EducationDetailsModel(IEducationService Service)
        {
            this.Service = Service;
        }

        public void OnGet(int id)
        {
            Education = Service.GetEducationDataById(id);
        }
    }
}
