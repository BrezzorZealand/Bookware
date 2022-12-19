using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IClassService classService;

        public OrderModel(IClassService service)
        {
            this.classService = service;
        }

        [BindProperty]
        public Class? _Class { get; set; }
        public IEnumerable<Class?>? classes { get; set; }

        public IActionResult OnGetAsync()
        {
            classes = classService.GetAll();
            return Page();
        }
    }
}
