using System;
using Bookware.Models;
using Bookware.DbServices.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public int CalculateSemester(Student? student)
        {
            int semester = 0;
            DateTime Startdate = student!.StartDate.Date;
            DateTime Enddate = DateTime.UtcNow;

            int months = (Enddate.Year - Startdate.Year)*12 + Enddate.Month-Startdate.Month;

            switch (months)
            {
                case <= 6:
                    semester = 1;
                    break;
                case <= 12:
                    semester = 2;                  
                    break;
                case <= 18:
                    semester = 3;                  
                    break;
                case <= 24:
                    semester = 4;                  
                    break;
                case <= 30:
                    semester = 5;                  
                    break;
                case <= 36:
                    semester = 6;                  
                    break;
                case <= 42:
                    semester = 7;                  
                    break;
                case <= 48:
                    semester = 8;                  
                    break;
                case <= 54:
                    semester = 9;                  
                    break;
                case <= 60:
                    semester = 10;                  
                    break;
            }

            return semester;
        }
    }
}


