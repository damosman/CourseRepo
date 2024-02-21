namespace Courses.Services
{
    public interface ICourse : IEntity
    {
        string? Name { get; set; }

        string? Description { get; set; }
    }
}
