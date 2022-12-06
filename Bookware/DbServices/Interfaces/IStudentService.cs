using System;
using Bookware.Models;
namespace Bookware.DbServices.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student?>> GetStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(Student? student);
        Task EditStudentAsync(Student? student);
        Task DeleteStudentAsync(Student? student);
        void CalculateSemester(Student student);
    }
}

