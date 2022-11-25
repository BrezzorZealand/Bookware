using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

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
        public Subject? GetSubject(int id)
        {
            return context.Subjects
                .AsNoTracking()
                .FirstOrDefault(s => s.SubjectId == id);
        }
        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects;
        }
    }
}
