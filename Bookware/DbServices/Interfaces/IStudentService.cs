using System;
using Bookware.Models;
namespace Bookware.DbServices.Interfaces
{
    public interface IStudentService : IGenericService<Student>
    {
        Task<Student?> GetByIdAsync(int? id);        
        Task<Student?> GetDataByIdAsync(int? id);
        void CalculateSemester(Student? student);
    }
}

