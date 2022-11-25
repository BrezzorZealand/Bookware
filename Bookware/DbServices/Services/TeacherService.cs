using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly BookwareDbContext context;

        public TeacherService(BookwareDbContext context)
        {
            this.context = context;
        }

        public void AddTeacher(Teacher? teacher)
        {
            if (teacher != null)
            {
                context.Teachers.Add(teacher);
                context.SaveChanges();
            }
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return context.Teachers;
        }

        public Teacher? GetTeacher(int id)
        {
            return context.Teachers
                .AsNoTracking()
                .FirstOrDefault(t => t.TeacherId == id);
        }

        public void EditTeacher(Teacher? teacher)
        {
            if (teacher != null)
            {
                context.Teachers.Update(teacher);
                context.SaveChanges();
            }
        }

        public void RemoveTeacher(Teacher? teacher)
        {
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
        }
    }
}
