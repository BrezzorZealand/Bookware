

using Microsoft.Extensions.Logging;
using Moq;

namespace BookwareUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //private Mock<IEducationService>? mockEduService = new Mock<IEducationService>();

        [TestMethod]
        public void TestCreateEduSub()
        {
            //// Arrange
            //var mockEducation = new Education();
            //mockEducation.EduId = 7;
            //mockEducation.EduName = "TestEdu";
            //var mockSubject = new Subject();
            //mockSubject.SubjectId = 4;
            //mockSubject.SubjectName = "TestSub";
            //var mockEduSub = new EduSub();

            //var mock = new Mock<IEducationService>();
            //mock.Setup(p => p.CreateEduSubAsync(It.IsAny<Education>(), mockSubject, mockEduSub));
            //var sut = new EducationService(mock.Object);

            //// ACT
            //sut.Ping();

            //// ASSERT
            //mock.Verify(p => p.CreateEduSubAsync(mockEducation, mockSubject, mockEduSub), Times.Once());
            //// Act

            //await mockEduService.CreateEduSubAsync(mockEducation, mockSubject, mockEduSub);

            //// Assert
            //Assert.IsNotNull(mockEduSub.EduSubId, "EduSubId is null");
            //Assert.IsNotNull(mockEduSub.Subject, "Subject is null");
            //Assert.IsNotNull(mockEduSub.Edu, "Edu is null");
        }


        //public async Task CreateEduSubAsync(Education? education, Subject? subject, EduSub? eduSub)
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