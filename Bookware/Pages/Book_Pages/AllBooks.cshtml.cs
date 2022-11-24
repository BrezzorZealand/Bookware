using Bookware.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Book_Pages
{
    public class AllBooksModel : PageModel
    {
        private readonly IBookService service;

        public IEnumerable<Book>? Books { get; set; }

        [BindProperty]
        public Book? Book { get; set; }
        public AllBooksModel(IBookService service)
        {
            this.service = service;
        }
        public IActionResult OnGet()
        {
            Books = service.GetBooks();
            return Page();
        }

        public IActionResult Delete(int id)
        {
            Book = service.GetBook(id);
            if (Book is null)
            {
                return NotFound();
            }
            return Partial("_DeleteBookPartialView", Book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            return Page();
        }
    }
}
