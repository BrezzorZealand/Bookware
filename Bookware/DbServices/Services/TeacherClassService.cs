using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class TeacherClassService : GenericService<TeacherClass>, ITeacherClassService
    {
        public TeacherClassService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<TeacherClass?> GetByIdAsync(int? TEid, int? Cid)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(tc => tc.TeachEduId == TEid && tc.ClassId == Cid);
        }

        public IEnumerable<SelectListItem> GetSelection(int Cid)
        {
            IEnumerable<TeacherClass> teacherClasses = GetAll().Where(tc => tc.ClassId == Cid).Include(tc => tc.Class).Include(tc => tc.TeachEdu).ThenInclude(te => te.Teacher).Include(tc => tc.TeachEdu).ThenInclude(te => te.EduSub).ThenInclude(es => es.Edu).Include(tc => tc.TeachEdu).ThenInclude(te => te.EduSub).ThenInclude(es => es.Subject);
            List<SelectListGroup> selectListGroups = new List<SelectListGroup>();
            foreach (var teacherClass in teacherClasses)
            {
                SelectListGroup selectListGroup = new SelectListGroup() { Name = teacherClass.TeachEdu.Teacher.Name };
                selectListGroups.Add(selectListGroup);
            }
            IEnumerable<SelectListItem> SelectListItems = from tc in teacherClasses
                                                          select new SelectListItem
                                                          {
                                                              Text = tc.TeachEdu.EduSub.EduSubDisplayName,
                                                              Value = tc.TeachEduId.ToString(),
                                                              Group = selectListGroups.FirstOrDefault(slg => slg.Name == tc.TeachEdu.Teacher.Name)
                                                          };
            return SelectListItems;
        }

        public async Task<bool> Exists(TeacherClass? teacherClass)
        {
            return GetAll().Contains(await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(tc => tc.TeachEduId == teacherClass!.TeachEduId && tc.ClassId == teacherClass!.ClassId));
        }
    }
}
