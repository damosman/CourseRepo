using Courses.Services;

namespace Courses.Entities
{
    public class Course : ICourse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateModified { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
