using System;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Interfaces
{
    public interface IStudentService : IGenericService<Student>
    {
        Task<Student?> GetByIdAsync(int? id);        
        Task<Student?> GetDataByIdAsync(int? id);
        SelectList GetSelection();
        int CalculateSemester(Student? student);
    }
}

