using Shouldly;
using Xunit;

namespace Courses.UnitTests.Services
{
    public class CourseCreateReqTest
    {
        [Fact]
        public void CreateReq()
        {
            //Arrange
            CourseCreateReqTest courseCreateReqTest = new CourseCreateReqTest();

            //Act
            var result = courseCreateReqTest.GetType();

            //Assert
            //use shouldly
            result.ShouldBeEquivalentTo(typeof(CourseCreateReqTest));
        }
    }
}
