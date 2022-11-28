using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface IEducationService
    {
        void CreateEducation(Education education);
        void DeleteEducation(Education education);
        void EditEducation(Education education);
        Education? GetEducation(int id);
        Education GetEducationDataById(int id);
        IEnumerable<Education> GetEducations();
    }
}