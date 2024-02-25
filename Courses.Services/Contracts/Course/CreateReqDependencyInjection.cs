using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Services.Contracts.Course
{
    public static class CreateReqDependencyInjection
    {
        public static IServiceCollection AddCreateReq(this IServiceCollection services) 
        {
            return services.AddScoped<IValidator<CourseCreateReq>, CourseCreateReqValidator>();

        }
    }
}