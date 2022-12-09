using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherService
    {
        Task AddTeacherAsync(Teacher? teacher);
        Task<IEnumerable<Teacher?>> GetTeachersAsync();

        Task<Teacher?> GetTeacherAsync(int id);
        Task<Teacher?> GetTeacherDataByIdAsync(int id);

        Task EditTeacherAsync(Teacher? teacher);
        Task RemoveTeacherAsync(Teacher? teacher);
        
        

    }
}
