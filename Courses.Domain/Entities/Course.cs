using Courses.Domain.Entities;

namespace Courses.Entities
{
    public class Course : Entity
    {
        public int CourseId { set; get; }

        public string CourseName { set; get; } = string.Empty;

        public string CourseDescription { set; get; } = string.Empty;

        public ICollection<Applicant>? Applicant { set; get; }
    }
}
