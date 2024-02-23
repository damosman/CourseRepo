namespace Courses.Services.Contracts
{
    public class BaseResponse
    {
        public string StatusCode { get; set; } = string.Empty;
        public string? Message { get; set; }
    }
}
