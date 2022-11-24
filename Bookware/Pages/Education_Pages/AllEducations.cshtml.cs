using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookware.Models;
using Bookware.DbServices.Interfaces;

namespace Bookware.Pages.Education_Pages
{
    public class AllEducationsModel : PageModel
    {
        public readonly IEducationService Service;
        public IEnumerable<Education>? Educations { get; set; }

        public AllEducationsModel(IEducationService Service)
        {
            this.Service = Service;
        }
        
        public void OnGet()
        {
            Educations = Service.GetEducations();
        }
    }
}
