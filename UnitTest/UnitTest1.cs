using Bookware.DbServices.Services;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            // Arrange
            BookwareDbContext context = new();
            EducationService sut = new(context);

            var mockEducation = new Education
            {
                EduId = 7,
                EduName = "TestEdu"
            };

            var mockSubject = new Subject
            {
                SubjectId = 4,
                SubjectName = "TestSub"
            };

            // Act
            await sut.AddSubjectAsync(mockEducation, mockSubject);

            // Assert
            Assert.IsNotNull(mockEducation.EduSubs, "EduSubs is null");
        }

        [TestMethod]
        public async Task TestGetSubjectsAsync()
        {
            //Arrange
            BookwareDbContext context = new BookwareDbContext();
            SubjectService sut2 = new(context);

            var mockSubject2 = new Subject
            {
                SubjectId = 5,
                SubjectName = "TestSubject2"
            };
            //Act
            await sut2.GetSubjectsAsync();
            //Assert

            Assert.IsNotNull(mockSubject2);
            //Assert.IsNull(subjects);
        }
        [TestMethod]
        public async Task TestRemoveSubjectAsync()
        {
            BookwareDbContext context = new BookwareDbContext();
            SubjectService sut3 = new(context);

            int NextSubjectNo = sut3.GetMaxSubjectNo() + 1;

            var mockSubject3 = new Subject
            {
                SubjectName = "TestSubject3"
            };
            await sut3.AddSubjectAsync(mockSubject3);

            Subject TestSubject = await sut3.GetSubjectByIdAsync(NextSubjectNo);

            await sut3.RemoveSubjectAsync(TestSubject);
            Subject removeSubject = await sut3.GetSubjectByIdAsync(NextSubjectNo);

            Assert.AreEqual(mockSubject3, TestSubject);
            Assert.IsNull(removeSubject);   
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

        }
    }
}