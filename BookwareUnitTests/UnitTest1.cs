

using Microsoft.Extensions.Logging;
using Moq;

namespace BookwareUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public async Task TestAddSubject()
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
        //public async Task AddSubjectAsync(Education? education, Subject? subject, EduSub? eduSub)
        //{
        //    if (education != null && subject != null && eduSub != null)
        //    {
        //        //eduSub.Edu = education;
        //        eduSub.EduId = education.EduId;
        //        //eduSub.Subject = subject;
        //        eduSub.SubjectId = subject.SubjectId;
        //        context.EduSubs.Add(eduSub);
        //    }
        //    await context.SaveChangesAsync();
        //}
    }
}