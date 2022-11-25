using Bookware.Interfaces;
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

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {                
                return Page();
            }
            service.CreateBook(Book);
            return RedirectToPage("AllBooks");
        }
    }
}
