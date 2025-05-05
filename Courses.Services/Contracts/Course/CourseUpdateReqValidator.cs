using FluentValidation;

namespace Courses.Services.Contracts.Course
{
    public class CourseUpdateReqValidator : AbstractValidator<CourseUpdateReq>
    {
        public CourseUpdateReqValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");

            RuleFor(x => x.CourseId)
                .NotEmpty()
                .WithMessage("CourseId field cannot be empty");

            RuleFor(x => x.CourseName)
                .NotEmpty()
                .WithMessage("Course Name field cannot be empty");

            RuleFor(x => x.CourseDescription)
                .NotEmpty()
                .WithMessage("Course Description field cannot be empty");
        }
    }
}