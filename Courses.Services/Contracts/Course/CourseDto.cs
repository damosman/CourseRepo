namespace Courses.Services.Contracts
{
    public class CourseDto
    {
        public int Id { set; get; }

        public int CourseId { set; get; }

        public string? CourseName { set; get; } = string.Empty;

        public string CourseDescription { set; get; } = string.Empty;
    }
}