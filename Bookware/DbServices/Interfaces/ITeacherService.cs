using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherService : IGenericService<Teacher>
    {
        Task<Teacher?> GetByIdAsync(int? id);
        Task<Teacher?> GetDataByIdAsync(int? id);
    }
}
