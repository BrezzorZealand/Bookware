using Bookware.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Book_Pages
{
    public class UpdateBookModel : PageModel
    {
        private readonly IBookService service;

        public UpdateBookModel(IBookService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Book? Book { get; set; } 

        public IActionResult OnGet(int id)
        {
            Book = service.GetBook(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            service.UpdateBook(Book);
            return RedirectToPage("AllBooks");
        }
    }
}
