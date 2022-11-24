using Bookware.DbServices.Interfaces;
using Bookware.Models;

namespace Bookware.DbServices.Services
{
    public class TeacherService : ITeacherService
    {
        readonly BookwareDbContext context;
        public TeacherService(BookwareDbContext context)
        {
            this.context = context;
        }

        public void AddTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();

        }

        public void EditTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return context.Teachers;
        }

        public void RemoveTeacher(Teacher teacher)
        {
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }
    }
}
