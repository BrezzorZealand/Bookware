﻿using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface ITeacherService
    {
        Task AddTeacherAsync(Teacher? teacher);
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher?> GetTeacherAsync(int id);
        Task EditTeacherAsync(Teacher? teacher);
        Task RemoveTeacherAsync(Teacher? teacher);
        Task AddEduAsync(EduSub? eduSub, Teacher? teacher);
        Task RemoveEduAsync(TeacherEdu teacherEdu);
        Task<TeacherEdu?> GetTeacherEduByIdAsync(int Tid, int ESid);
    }
}
