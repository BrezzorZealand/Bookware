using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;




namespace Bookware.Pages.Teacher_Pages
{
    public class AllTeachersModel : PageModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public int TId { get; set; }
        private ITeacherService context;

        public AllTeachersModel(ITeacherService service)
        {
            context = service;
        }
            
        public void OnGet(int tid)
        {
            TId = tid;
            Teachers = context.GetTeachers();
        }
    }
}
