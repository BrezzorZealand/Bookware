using System;
using System.Collections.Generic;
using System.Net;
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JsonGenerator
{
    class Program
    {
        static public BookwareDbContext GetDBcontext()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookwareDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            DbContextOptionsBuilder<BookwareDbContext> Builder = new DbContextOptionsBuilder<BookwareDbContext>()
                .UseSqlServer(connectionString);
            return new BookwareDbContext(Builder.Options);
        }
        
        static void Main(string[] args)
        {

            List<Student> students = new();

            List<string> names = new() { "Alice", "Bob", "Charlie", "Dave", "Eve" };
            List<string> surnames = new() { "Smith", "Johnson", "Williams", "Jones", "Brown" };

            for (int i = 0; i < 20; i++)
            {
                students.Add(CreateMyObject(names, surnames));
            }
            
            int nextid = 2000;
            List<string> SQLstrings = new();
            foreach (var obj in students)
            {
                nextid++;
                SQLstrings.Add($"INSERT INTO[dbo].[Student] ([Student_Id], [StudentName], [Address], [StartDate], [Class_Id]) VALUES({nextid}, N'{obj.StudentName}', N'{obj.Address}', N'{obj.StartDate}', {obj.ClassId});\n");
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "queries.sql");
            try
            {
                foreach (var strings in SQLstrings)
                {
                    File.AppendAllText(filePath, strings);
                }
                Console.WriteLine("File created or changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
        }

        static Student CreateMyObject(List<string> names, List<string> surnames)
        {
            Random rnd = new();
            BookwareDbContext context = GetDBcontext();
            ClassService classService = new(context);
            int rndmax;
            int rndmin = classService.GetAll().First().ClassId;
            int? classId = null;

            if (classService.GetAll().Count() % 4 != 0)
            {
                rndmax = classService.GetAll().Count();
                classId = rnd.Next(rndmin, rndmax + 1);
            }

            int nameIndex = rnd.Next(names.Count);
            int surnameIndex = rnd.Next(surnames.Count);

            return new Student
            {
                StudentName = names[nameIndex] + " " + surnames[surnameIndex],
                Address = "Mock Address",
                StartDate = DateTime.Now.AddMonths(-rnd.Next(1, 12)).Date,
                ClassId = classId
            };
        }
    }
}
