using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface ISubjectService
    {
        //public IEnumerable<Subject> GetSubjectsAsync(string filter);
        Task <IEnumerable<Subject>> GetSubjectsAsync();
        Task<Subject?> GetSubjectByIdAsync(int id);
        Task AddSubjectAsync(Subject subject);
        Task RemoveSubjectAsync(Subject subject);
        Task EditSubjectAsync(Subject subject);
        Task<Subject?> GetSubjectDataById(int id);
        //Task GetSubjectAsync(int id);
    }
}
