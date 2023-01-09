using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
            Console.WriteLine("what do you want to create?");
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. All");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("how many books do you want to create?");
                    BookToFile(GetAmountToCreate());
                    break;
                case "2":
                    Console.WriteLine("how many Students do you want to create?");
                    StudentToFile(GetAmountToCreate());
                    break;
                case "3":
                    Console.WriteLine("how many books do you want to create?");
                    BookToFile(GetAmountToCreate());
                    Console.WriteLine("how many Students do you want to create?");
                    StudentToFile(GetAmountToCreate());
                    break;
                default:
                    Console.WriteLine("invalid input");
                    Console.ReadKey();
                    break;
            }
        }

        static void ToFile(List<string> list)
        {
            List<string> SQLstrings = list;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "queries.sql");
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
        
        static void BookToFile(int items)
        {
            Random rnd = new();
            List<Book> books = new();

            List<string> titles = new() {"Alice"};
            List<string> authors = new() {"Smith"};
            
            for (int i = 0; i < items; i++)
            {
                books.Add(CreateBook(titles, authors));
            }

            List<string> SQLstrings = new();
            foreach (var obj in books)
            {
                SQLstrings.Add($"INSERT INTO [dbo].[Book] ([Book_Id], [Title], [Author], [Year], [ISBN]) VALUES ({rnd.Next(100, 1000)}, N'{obj.Title}', N'{obj.Author}', {obj.Year}, NULL)\n");
            }
            
            ToFile(SQLstrings);
        }
        static Book CreateBook(List<string> titles, List<string> authors)
        {
            Random rnd = new();
            
            int titleIndex = rnd.Next(titles.Count);
            int authorIndex = rnd.Next(authors.Count);
            
            return new Book
            {
                Title = titles[titleIndex],
                Author = authors[authorIndex],
                Year = rnd.Next(1960,2022),
            };
        }

        static void StudentToFile(int items)
        {
            Random rnd = new();
            List<Student> students = new();

            List<string> names = new() { 
                "Alice",
                "Bob",
                "Charlie",
                "Dave",
                "Eve",
                "Frank",
                "Gina",
                "Harriet",
                "Igor",
                "Jill",
                "Kate",
                "Liam",
                "Maggie",
                "Nancy",
                "Owen",
                "Patty" };
            List<string> surnames = new() { 
                "Smith",
                "Johnson",
                "Williams",
                "Jones",
                "Brown",
                "Davis",
                "Miller",
                "Wilson",
                "Moore",
                "Taylor",
                "Anderson",
                "Thomas",
                "Jackson",
                "White",
                "Harris",
                "Martin" };

            for (int i = 0; i < items; i++)
            {
                students.Add(CreateStudent(names, surnames));
            }


            List<string> SQLstrings = new();
            foreach (var obj in students)
            {
                SQLstrings.Add($"INSERT INTO[dbo].[Student] ([Student_Id], [StudentName], [Address], [StartDate], [Class_Id]) VALUES({rnd.Next(2000, 10000)}, N'{obj.StudentName}', N'{obj.Address}', N'{obj.StartDate}', {obj.ClassId})\n");
            }

            ToFile(SQLstrings);
        }
        static Student CreateStudent(List<string> names, List<string> surnames)
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

        static int GetAmountToCreate()
        {
            int amount = 0;
            while (amount == 0)
            {
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number");
                }
            }
            return amount;
        }
    }
}
