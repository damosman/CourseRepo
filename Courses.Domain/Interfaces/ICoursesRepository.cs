using Courses.Entities;

namespace Courses.Domain.Interfaces
{
    public interface ICoursesRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> Add(Course course);
        Task<Course> Update(Course course);
        Task<Course> GetById(int courseId);
        Task<bool> Delete(int courseId);
    }
}