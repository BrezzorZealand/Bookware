using System;
using Bookware.Models;
using Bookware.Interfaces;
using Bookware.DbServices.Interfaces;

namespace Bookware.DbServices.Services
{
	public class StudentService : IStudentService
	{
        private readonly BookwareDbContext context;

        public StudentService(BookwareDbContext context)
        {
            this.context = context;
        }
        public Student? GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            throw new NotImplementedException();
        }

        
    }
}

