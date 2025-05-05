namespace Courses.Services.Contracts
{
    public class CourseUpdateRsp<T> : BaseResponse
    {
        public T? Value { get; set; }
    }
}