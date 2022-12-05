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
            CalculateSemester(student);
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
            CalculateSemester(student);
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void CalculateSemester(Student student)
        {
            DateTime Startdate = student.StartDate;
            DateTime Enddate = DateTime.UtcNow;

            int months = (Enddate.Year - Startdate.Year)*12 + Enddate.Month-Startdate.Month;

            switch (months)

            {
                case <= 6:
                    student.Semester = 1;
                    break;
                case <= 12:
                    student.Semester = 2;
                    break;
                case <= 18:
                    student.Semester = 3;
                    break;
                case <= 24:
                    student.Semester = 4;
                    break;
                case <= 30: 
                    student.Semester = 5;
                    break;
                case <= 36:
                    student.Semester = 6;
                    break;
                case <= 42:
                    student.Semester = 7;
                    break;
                case <= 48:
                    student.Semester = 8;
                    break;
            }
        }


    }
}


