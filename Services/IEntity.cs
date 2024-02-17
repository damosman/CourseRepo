namespace Courses.Services
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }

        string? CreatedBy { get; set; }

        string? ModifiedBy { get; set; }
    }
}
