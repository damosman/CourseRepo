namespace Courses.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public Course() { }
    }
}
