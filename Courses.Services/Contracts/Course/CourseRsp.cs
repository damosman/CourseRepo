namespace Courses.Services.Contracts
{
    public class CourseRsp<T> : BaseResponse
    {
        public T? Value { get; set; }
    }
}