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
    }
}
