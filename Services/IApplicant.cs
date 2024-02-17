namespace Courses.Services
{
    public interface IApplicant : IEntity
    {
        int CourseId { get; set; }

        string? FirstName { get; set; }

        string? LastName { get; set; }

        string? Email { get; set; }

        int PhoneNumber { get; set; }

        string? Gender { get; set; }

        string? Nationality { get; set; }

        string? StreetName { get; set; }

        string? City { get; set; }

        string? Country { get; set; }

        string? CurrentDevSkill { get; set; }

        string? EmploymentStatus { get; set; }

    }
}
