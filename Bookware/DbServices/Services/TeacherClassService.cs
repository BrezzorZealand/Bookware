using Bookware.DbServices.Interfaces;
using Bookware.Models;

namespace Bookware.DbServices.Services
{
    public class TeacherClassService : GenericService<TeacherClass>
    {
        public TeacherClassService(BookwareDbContext context) : base(context)
        {
        }


        
    }
}
