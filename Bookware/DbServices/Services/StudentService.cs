using System;
using Bookware.Models;
using Bookware.DbServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookware.DbServices.Services
{
    public class StudentService : GenericService<Student> , IStudentService
    {
        public StudentService(BookwareDbContext context) : base(context)
        {
        }

        public async Task<Student?> GetByIdAsync(int? id)
        {
            return await GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<Student?> GetDataByIdAsync(int? id)
        {
            return await GetAll()
                .Include(s => s.Class)
                .ThenInclude(c => c.ClassBooks)
                .ThenInclude(cb => cb.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public void CalculateSemester(Student? student)
        {
            DateTime Startdate = student!.StartDate;
            DateTime Enddate = DateTime.UtcNow;

            int months = (Enddate.Year - Startdate.Year)*12 + Enddate.Month-Startdate.Month;

            switch (months)

            {
                case <= 6:
                    student.Semester = 1;
                    break;
                case <= 12:
                    student.Semester = 2;
                    break;
                case <= 18:
                    student.Semester = 3;
                    break;
                case <= 24:
                    student.Semester = 4;
                    break;
                case <= 30: 
                    student.Semester = 5;
                    break;
                case <= 36:
                    student.Semester = 6;
                    break;
                case <= 42:
                    student.Semester = 7;
                    break;
                case <= 48:
                    student.Semester = 8;
                    break;
                case <= 54:
                    student.Semester = 9;
                    break;
                case <= 60:
                    student.Semester = 10;
                    break;
                    default:
                    student.Semester = 0;
                    break;
            }
        }

        /* Get Selection of Students */
        public SelectList GetSelection()
        {
            return new SelectList(GetAll().ToList(), nameof(Student.StudentId), nameof(Student.StudentName));
        }
    }
}


