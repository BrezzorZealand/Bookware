using Bookware.DbServices.Interfaces;
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await service.GetByIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await service.Update(Book!);
            return RedirectToPage("AllBooks");
        }
    }
}
