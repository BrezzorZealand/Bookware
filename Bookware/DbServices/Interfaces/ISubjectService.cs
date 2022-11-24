using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface ISubjectService
    {
        public IEnumerable<Subject> GetSubjects();
        void AddSubject(Subject subject);
        void RemoveSubject(Subject subject);
        void EditSubject(Subject subject);

        Subject GetSubject(int id);
    }
}
