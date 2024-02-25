using Courses.Services.Implementations;
using Courses.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Services
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services.AddScoped<ICourseService, CourseService>();
        }
    }
}