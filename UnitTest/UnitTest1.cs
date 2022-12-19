using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Bookware.Pages.Subject_Pages;
using Bookware.DbServices.Interfaces;
using System.Security.Cryptography.X509Certificates;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookwareDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string? SubjectName { get; private set; }

        public BookwareDbContext GetDBcontext()
        {
            DbContextOptionsBuilder<BookwareDbContext> Builder = new DbContextOptionsBuilder<BookwareDbContext>()
                .UseSqlServer(connectionString);
            return new BookwareDbContext(Builder.Options);
        }

        [TestMethod]
        public async Task TestCreate()
        {
            BookwareDbContext context = GetDBcontext();
            SubjectService sut = new SubjectService(context);

            var mockSubject = new Subject
            {
                SubjectName = "TestSub"
            };

            // Act
            await sut.Create(mockSubject);

            // Assert
            Assert.IsNotNull(mockSubject);
        }

        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            BookwareDbContext context = GetDBcontext();

            SubjectService sut2 = new SubjectService(context);


            //Act
            IEnumerable<Subject> subjects = sut2.GetAll();
            //Assert

            Assert.IsNotNull(subjects);
            //Assert.IsNull(subjects);
        }
        [TestMethod]
        public async Task TestRemoveSubjectAsync()
        {
            BookwareDbContext context = GetDBcontext();

            SubjectService sut3 = new SubjectService(context);
            Subject Last_subject;
            Subject Last_subject2;


            Subject mockSubject3 = new Subject
            {
                SubjectName = "testsubremove"
            };
            
            Last_subject = sut3.GetAll().OrderBy(x => x.SubjectId).Last();
            Subject last1 = Last_subject;

            await sut3.Create(mockSubject3);

            await sut3.Delete(mockSubject3);

            Last_subject2 = sut3.GetAll().OrderBy(x => x.SubjectId).Last();
            Subject last2 = Last_subject2;

            Assert.AreNotEqual(last1, last2);
        }
        [TestMethod]
        public async Task TestUpdateSubject()
        {
            BookwareDbContext context = GetDBcontext();
            SubjectService sut4 = new(context);
            string SubjectName = "TestEdit";

            //Subject mockSubject4ToUpdate = new Subject
            //{
            //    this.SubjectName = SubjectName
            //};

            Subject? mockSubject4ToUpdate = new Subject { SubjectName = SubjectName };

            await sut4.Create(mockSubject4ToUpdate);

            mockSubject4ToUpdate = sut4.GetAll().AsNoTracking().FirstOrDefault(sub => sub.SubjectName == mockSubject4ToUpdate.SubjectName);
            mockSubject4ToUpdate!.SubjectName = "SaveEdit";

            if (mockSubject4ToUpdate != null)
            {
                await sut4.Update(mockSubject4ToUpdate);
            };

            Assert.AreNotEqual(mockSubject4ToUpdate!.SubjectName, SubjectName);

        }
    }
}