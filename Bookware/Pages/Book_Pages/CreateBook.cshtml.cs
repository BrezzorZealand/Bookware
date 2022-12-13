using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Book_Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly IBookService service;

        public CreateBookModel(IBookService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGetAsync()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {                
                return Page();
            }

            await service.Create(Book!);

            return RedirectToPage("AllBooks");
        }
    }
}
