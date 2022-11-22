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

        public AllBooksModel(IBookService service)
        {
            this.service = service;
        }
        public void OnGet()
        {
            Books = service.GetBooks();
        }
    }
}
