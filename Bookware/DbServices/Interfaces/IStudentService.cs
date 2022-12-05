using System;
using Bookware.Models;
namespace Bookware.DbServices.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student?>> GetStudentsAsync();
        Task<Student?> GetStudentsAsync(int id);
        Student? GetStudentById(int id);
        Task CreateStudentAsync(Student? student);
        Task EditStudentAsync(Student? student);
        Task<Student?> GetStudentDataById(int id);
        void RemoveStudent(Student student);
        void EditStudent(Student student);
        void AddStudent(Student student);
        //int CalculateSemester(int semesterId);
    }
}

