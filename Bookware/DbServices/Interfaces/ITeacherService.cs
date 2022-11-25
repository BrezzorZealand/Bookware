using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherService
    {
        void AddTeacher(Teacher? teacher);

        IEnumerable<Teacher> GetTeachers();

        Teacher? GetTeacher(int id);

        void EditTeacher(Teacher? teacher);
        void RemoveTeacher(Teacher? teacher);
        
        

    }
}
