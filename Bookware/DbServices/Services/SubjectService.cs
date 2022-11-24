using Bookware.DbServices.Interfaces;
using Bookware.Models;

namespace Bookware.DbServices.Services
{
    public class SubjectService : ISubjectService
    {
        BookwareDbContext context;
        public SubjectService(BookwareDbContext context)
        {
            this.context = context;
        }

        public void AddSubject (Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }
        public void RemoveSubject(Subject subject)
        {
            context.Subjects.Remove(subject);
            context.SaveChanges();
        }
        public void EditSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
        public Subject GetSubject(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects;
        }
    }
}
