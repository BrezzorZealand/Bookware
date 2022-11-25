using Bookware.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Book_Pages
{
    public class AllBooksModel : PageModel
    {
        private readonly IBookService service;


        public AllBooksModel(IBookService service)
        {
            this.service = service;
        }
        [BindProperty]
        public Book? Book { get; set; }
        public IEnumerable<Book>? Books { get; set; }
        public IActionResult OnGet()
        {
            Books = service.GetBooks();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            Book = service.GetBook(id);
            if (Book == null)
            {
                return Page();
            }
            service.DeleteBook(Book);
            return RedirectToPage("AllBooks");
        }
    }
}
