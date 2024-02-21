using Courses.Services;

namespace Courses.Entities
{
    public class Applicant : IApplicant
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public int PhoneNumber { get; set; }

        public string? Gender { get; set; }

        public string? Nationality { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GroupId { get; set; }

        public List<string>? ExistingDevSkill { get; set; } = new List<string>();

        public List<string>? EmploymentStatus { get; set; } = new List<string>();

        public string? StreetName { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateModified { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
