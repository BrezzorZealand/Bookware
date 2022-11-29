using System;
using Bookware.Models;
using Bookware.Interfaces;
using Bookware.DbServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
	public class StudentService : IStudentService
	{
        private readonly BookwareDbContext context;

        public StudentService(BookwareDbContext context)
        {
            this.context = context;
        }

        public async Task EditStudentAsync(Student? student)
        {
            if (student != null)
            {
                context.Students.Update(student);

            }
            await context.SaveChangesAsync();
        }

        public async Task<Student?> GetStudentsAsync(int id)
        {
            Student? student = await context.Students
                .AsNoTracking().FirstOrDefaultAsync(s => s.StudentId == id);
                
            return student;
        }

        public async Task<IEnumerable<Student?>> GetStudentsAsync()
        {
            return await context.Set<Student>().AsNoTracking().ToListAsync();
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

