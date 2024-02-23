using FluentValidation;

namespace Courses.Services.Contracts.Course
{
    public class CourseCreateReqValidator : AbstractValidator<CourseCreateReq>
    {
        public CourseCreateReqValidator()
        {
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