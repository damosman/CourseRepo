using Courses.Domain.Entities;

namespace Courses.Entities
{
    public class Applicant : Entity
    {
        public int CourseId { set; get; }

        public int ApplicantId { set; get; }

        public string FirstName { set; get; } = string.Empty;

        public string LastName { set; get; } = string.Empty;

        public string Email { set; get; } = string.Empty;

        public int PhoneNumber { set; get; }

        public string Gender { set; get; } = string.Empty;

        public string Nationality { set; get; } = string.Empty;

        public DateTime DateOfBirth { set; get; }

        public int GroupId { set; get; } 

        public List<string>? ExistingDevSkill { set; get; } = new List<string>();

        public List<string>? EmploymentStatus { set; get; } = new List<string>();

        public string StreetName { set; get; } = string.Empty;

        public string City { set; get; } = string.Empty;

        public string Country { set; get; } = string.Empty;
    }
}