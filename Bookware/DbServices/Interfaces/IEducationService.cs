using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface IEducationService
    {
        Task CreateEducationAsync(Education? education);
        Task DeleteEducationAsync(Education? education);
        Task EditEducationAsync(Education? education);
        Task<Education?> GetEducationByIdAsync(int id);
        Task<Education?> GetEducationDataByIdAsync(int id);
        Task<IEnumerable<Education?>> GetEducationsAsync();
    }
}