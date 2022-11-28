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
        public IEnumerable<Book?> ?Books { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Books = await service.GetBooksAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Book = await service.GetBookByIdAsync(id);

            if (Book == null)
            {
                return Page();
            }

            await service.DeleteBookAsync(Book);
            return RedirectToPage("AllBooks");
        }
    }
}
