using Bookware.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookware.Pages.Book_Pages
{
    public class BookDetailsModel : PageModel
    {
        private readonly IBookService service;
        public BookDetailsModel(IBookService service)
        {
            this.service = service;
        }
        public Book? Book { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await service.GetBookDataByIdAsync(id);

            if (Book is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
