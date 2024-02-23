namespace Courses.Services.Contracts
{
    public class CourseUpdateReq : CourseCreateReq
    {
        public int Id { set; get; }
    }
}