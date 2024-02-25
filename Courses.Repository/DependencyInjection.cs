using Courses.Domain.Interfaces;
using Courses.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Repository
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddRepository(this IServiceCollection services) 
        {
            return services.AddScoped<ICoursesRepository, CoursesRepository>();
        }
    }
}