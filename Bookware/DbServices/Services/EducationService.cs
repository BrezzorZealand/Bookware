using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;

namespace Bookware.DbServices.Services
{
    public class EducationService : GenericService<Education> , IEducationService
    {
        public EducationService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<Education?> GetByIdAsync(int? id)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(ed => ed.EduId == id);
        }

        public async Task<Education?> GetDataByIdAsync(int? id)
        {
            return await GetAll()
                .Include(es => es.EduSubs)
                .ThenInclude(s => s.Subject)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EduId == id);            
        }
    }
}
