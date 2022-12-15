<<<<<<< HEAD
using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Bookware.Pages.Subject_Pages;
using Bookware.DbServices.Interfaces;

=======
>>>>>>> f5f491a6a649a2267a6bae5121d5d348a731e255
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
<<<<<<< HEAD
            // Arrange
            BookwareDbContext context = new();
            EducationService sut = new(context);

            var mockEducation = new Education
            {
                EduName = "TestEdu"
            };

            var mockSubject = new Subject
            {
                SubjectName = "TestSub"
            };

            // Act
            //await sut.Create(mockEducation, mockSubject);

            // Assert
            Assert.IsNotNull(mockEducation.EduSubs, "EduSubs is null");
        }

        [TestMethod]
        public void TestGetSubjects()
        {
            //Arrange
            BookwareDbContext context = new BookwareDbContext();
            SubjectService sut2 = new(context);

            var mockSubject2 = new Subject
            {
                SubjectName = "TestSubject2"
            };
            //Act
            sut2.GetAll();
            //Assert

            Assert.IsNotNull(mockSubject2);
            //Assert.IsNull(subjects);
        }
        [TestMethod]
        public async Task TestRemoveSubjectAsync()
        {
            BookwareDbContext context = new BookwareDbContext();
            SubjectService sut3 = new(context);
            Subject Last_subject;
            Subject Last_subject2;


            var mockSubject3 = new Subject
            {
                SubjectName = "TestSubject3"
            };
            var mockSubject4 = new Subject
            {
                SubjectName = "TestSubject"
            };

            await sut3.Create(mockSubject3);

            Last_subject = sut3.GetAll().Last();
            int last1 = Last_subject.SubjectId;

            await sut3.Delete(mockSubject3);

            Last_subject2 = sut3.GetAll().Last();
            int last2 = Last_subject2.SubjectId;

            Assert.AreEqual(last1, last2); 
            //if (mockSubject3 != null)
            //{
            //  await sut3.RemoveSubjectAsync(mockSubject3);
            //}
            //try
            //{
            //    Assert.AreSame(mockSubject3, await sut3.GetSubjectByIdAsync(mockSubject3.SubjectId));
                
            //}
            //catch (Exception ex)
            //{
            //    Assert.Fail(ex.Message);
            //}
        }
        [TestMethod]
        public async Task TestEditSubjectAsync()
        {
            BookwareDbContext context = new BookwareDbContext();
            SubjectService sut4 = new(context);

=======
>>>>>>> f5f491a6a649a2267a6bae5121d5d348a731e255
        }
    }
}