using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Services.Contracts.Course
{
    public static class UpdateReqDependencyInjection
    {
        public static IServiceCollection UpdateCreateReq(this IServiceCollection services) 
        {
            return services.AddScoped<IValidator<CourseUpdateReq>, CourseUpdateReqValidator>();

        }
    }
}