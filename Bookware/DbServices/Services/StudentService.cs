using System;
using Bookware.Models;
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

        public async Task CreateStudentAsync(Student? student)
        {
            if (student != null)
            {
                context.Students.Add(student);
            }
            await context.SaveChangesAsync();
        }

        public async Task EditStudentAsync(Student? student)
        {
            if (student != null)
            {
                context.Students.Update(student);

            }
            await context.SaveChangesAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            Student? student = await context.Students
                .AsNoTracking().FirstOrDefaultAsync(s => s.StudentId == id);

            return student;
        }

        public async Task<IEnumerable<Student?>> GetStudentsAsync()
        {
            return await context.Set<Student>().AsNoTracking().ToListAsync();
        }        

        public IEnumerable<Student?> GetStudents()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStudentAsync(Student? student)
        {
            if (student != null)
            {
                context.Students.Remove(student);
            }            
            await context.SaveChangesAsync();
        }
    }
}


