using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookware.Pages.Order_Pages
{
    public class OrderItemsModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly IClassBookService classBookService;
        private readonly IClassService classService;

        public OrderItemsModel(IOrderService orderService, IClassBookService classBookService, IClassService classService)
        {
            this.orderService = orderService;
            this.classBookService = classBookService;
            this.classService = classService;
        }

        public int? ClassId { get; set; }

        public string? ClassName { get; set; }

        public IEnumerable<SelectListItem>? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public Order? Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClassId= id;
            Class? _class = await classService.GetClassByIdAsync(id);
            ClassName = _class!.ClassName;
            Options = classBookService.GetClassBookSelection(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await orderService.Create(Order);
            return RedirectToPage("OrderClasses");
        }
    }
}
