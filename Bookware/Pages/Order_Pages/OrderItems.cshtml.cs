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

        public OrderItemsModel(IOrderService orderService, IClassBookService classService)
        {
            this.orderService = orderService;
            this.classBookService = classService;
        }

        public int? ClassId { get; set; }

        public IEnumerable<SelectListItem>? Options { get; set; }

        [BindProperty(SupportsGet = true)]
        public Order? Order { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            ClassId= id;
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
