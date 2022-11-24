using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface IEducationService
    {
        void CreateEducation(Education education);
        void DeleteEducation(Education education);
        void EditEducation(int id);
        Education? GetEducation(int id);
        IEnumerable<Education> GetEducations();
    }
}