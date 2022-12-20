using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Order_Pages
{
    public class OrderViewModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly IClassService classService;

        public OrderViewModel(IOrderService orderService, IClassService classService)
        {
            this.orderService = orderService;
            this.classService = classService;
        }

        public Class? Class { get; set; }

        public IEnumerable<Order>? Orders { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Class = await classService.GetClassByIdAsync(id);
            Orders = orderService.GetOrdersByIdAsync(id);

            if (Orders != null)
            {
                return Page();
            }

            return NotFound();
        }
    }
}
