using System;
using Bookware.Models;
namespace Bookware.DbServices.Interfaces
{
	public interface IStudentService
	{
        IEnumerable<Student> GetStudents();
        Student? GetStudentById(int id);
        void RemoveStudent(Student student);
        void EditStudent(Student student);
        void AddStudent(Student student);
    }
}

