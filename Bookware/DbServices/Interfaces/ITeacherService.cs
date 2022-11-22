using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetTeachers();
        void AddTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);
        void EditTeacher(Teacher teacher);
        Teacher GetTeacher(int id);

    }
}
