using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Bookware.DbServices.Services
{
    public class EduSubService : GenericService<EduSub>, IEduSubService
    {
        public EduSubService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<EduSub?> GetByIdAsync(int? Eid, int? Sid)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.EduId == Eid && es.SubjectId == Sid);
        }

        public SelectList GetSelection(int? Eid)
        {
            IEnumerable<EduSub> eduSubs = GetAll().Where(es => es.EduId == Eid).Include(es => es.Subject);
            List<Subject> subjects = new List<Subject>();
            foreach (var eduSub in eduSubs)
            {
                subjects.Add(eduSub.Subject);
            }
            return new SelectList(subjects, nameof(Subject.SubjectId), nameof(Subject.SubjectName));
        }

        public IEnumerable<SelectListItem> GetAllSelection()
        {
            IEnumerable<EduSub> eduSubs = GetAll().Include(es => es.Subject).Include(es => es.Edu);
            List<SelectListGroup> selectListGroups = new List<SelectListGroup>();
            foreach (var eduSub in eduSubs)
            {
                SelectListGroup selectListGroup = new SelectListGroup() { Name = eduSub.Edu.EduName };
                selectListGroups.Add(selectListGroup);
            }
            IEnumerable<SelectListItem> SelectListItems = from es in eduSubs
                                               select new SelectListItem
                                               {
                                                   Text = es.Subject.SubjectName,
                                                   Value = es.EduSubId.ToString(),
                                                   Group = selectListGroups.FirstOrDefault(slg => slg.Name == es.Edu.EduName)
                                               };
            return SelectListItems;
        }

        public async Task<bool> Exists(EduSub? eduSub)
        {
            return GetAll().Contains(await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.EduId == eduSub!.EduId && es.SubjectId == eduSub!.SubjectId));
        }
    }
}