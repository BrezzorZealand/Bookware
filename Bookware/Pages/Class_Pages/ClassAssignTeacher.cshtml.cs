using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookware.Models;

namespace Bookware.Pages.Class_Pages
{
    public class ClassAssignTeacherModel : PageModel
    {
        //private readonly ITeacherClassService teacherClassService

        //public ClassAssignTeacherModel(Bookware.Models.BookwareDbContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult OnGet()
        //{
        //ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
        //ViewData["TeachEduId"] = new SelectList(_context.TeacherEdus, "TeachEduId", "TeachEduId");
        //    return Page();
        //}

        //[BindProperty]
        //public TeacherClass TeacherClass { get; set; }
        

        //public async Task<IActionResult> OnPostAsync()
        //{
        //  if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.TeacherClasses.Add(TeacherClass);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
