using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface IEducationService
    {
        Task CreateEducationAsync(Education? education);
        Task AddSubjectAsync(Education? education, Subject? subject);
        Task DeleteEducationAsync(Education? education);
        Task EditEducationAsync(Education? education);
        Task<Education?> GetEducationByIdAsync(int id);
        Task<Education?> GetEducationDataByIdAsync(int id);
        Task<IEnumerable<Education?>> GetEducationsAsync();
        Task RemoveSubjectAsync(EduSub eduSub);
        Task<EduSub?> GetEduSubByIdAsync(int Eid, int Sid);
        Task<IEnumerable<EduSub?>> GetEduSubsByIdAsync(int Eid);
    }
}