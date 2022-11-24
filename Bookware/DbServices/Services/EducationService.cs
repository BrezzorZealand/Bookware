using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class EducationService : IEducationService
    {
        private readonly BookwareDbContext context;

        public EducationService(BookwareDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Education> GetEducations()
        {
            return context.Educations;
        }

        public Education? GetEducation(int id)
        {
            return context.Educations
                .Include(es => es.EduSubs)
                .AsNoTracking()
                .FirstOrDefault(e => e.EduId == id);
        }

        public void EditEducation(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateEducation(Education education)
        {
            context.Educations.Add(education);
            context.SaveChanges();
        }

        public void DeleteEducation(Education education)
        {
            context.Educations.Remove(education);
            context.SaveChanges();
        }
    }
}
