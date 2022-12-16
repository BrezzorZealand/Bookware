using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Bookware.DbServices.Services
{
    public class TeacherEduService : GenericService<TeacherEdu>, ITeacherEduService
    {
        public TeacherEduService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<TeacherEdu?> GetByIdAsync(int? ESid, int? Tid)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(te => te.TeacherId == Tid && te.EduSubId == ESid);
        }

        /* Get a Selection of TeacherEducations */
        public SelectList GetSelection(int Tid)
        {
            IEnumerable<TeacherEdu> teacherEdus = GetAll().Where(te => te.TeacherId == Tid).Include(te => te.EduSub.Subject);
            List<Subject> subjects = new List<Subject>();
            foreach (var teacherEdu in teacherEdus)
            {
                subjects.Add(teacherEdu.EduSub.Subject);
            }

            return new SelectList(subjects, nameof(Subject.SubjectId), nameof(Subject.SubjectName));
        }

        public IEnumerable<SelectListItem> GetAllSelection()
        {
            IEnumerable<TeacherEdu> teacherEdus = GetAll().Include(t => t.Teacher).Include(es => es.EduSub).ThenInclude(s => s.Subject).Include(es => es.EduSub).ThenInclude(e => e.Edu);
            List<SelectListGroup> selectListGroups = new List<SelectListGroup>();
            foreach (var teacherEdu in teacherEdus)
            {
                SelectListGroup selectListGroup = new SelectListGroup() { Name = teacherEdu.Teacher.Name };
                selectListGroups.Add(selectListGroup);
            }
            IEnumerable<SelectListItem> SelectListItems = from te in teacherEdus
                                                          select new SelectListItem
                                                          {
                                                              Text = te.EduSub.Edu.EduName,
                                                              Value = te.TeachEduId.ToString(),
                                                              Group = selectListGroups.FirstOrDefault(slg => slg.Name == te.Teacher.Name)
                                                          };
            return SelectListItems;
        }
    }
}
