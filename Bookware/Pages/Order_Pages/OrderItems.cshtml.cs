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
        private readonly IClassBookService classBookService;
        private readonly IBookService bookService;

        public OrderItemsModel(IClassBookService classService, IBookService bookService)
        {
            this.classBookService = classService;
            this.bookService = bookService;
        }

        public SelectList? Options { get; set; }

        public List<int>? OrderItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public ClassBook? ClassBook { get; set; } = new ClassBook();

        public IActionResult OnGetAsync(int id)
        {
            ClassBook!.ClassId = id;
            Options = classBookService.GetSelection(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Options = classBookService.GetSelection(ClassBook!.ClassId);
                return Page();
            }

            if (await classBookService.Exists(ClassBook))
            {
                return RedirectToPage("Order");
            }

            //await classBookService.Create(ClassBook);
            return RedirectToPage("Order");
        }
    }
}
