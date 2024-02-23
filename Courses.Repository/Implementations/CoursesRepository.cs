using Courses.Domain.Interfaces;
using Courses.Entities;
using Courses.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Courses.Repository.Implementations
{
    public class CoursesRepository : ICoursesRepository
    {
        public CoursesDbContext _courseDbContext;

        public CoursesRepository(CoursesDbContext courseDbContext)
        {
            _courseDbContext = courseDbContext;
        }
        public async Task<Course> Add(Course course)
        {
            _courseDbContext.Add(course);
            _courseDbContext.SaveChanges();
            return await Task.FromResult(course);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await Task.FromResult(_courseDbContext
                .Courses
                .ToList());
        }

        public async Task<Course> GetById(int courseId)
        {
            Course? course = await _courseDbContext
                 .Courses
                 .Where(x => x.CourseId == courseId)
                 .FirstOrDefaultAsync();

            return course;
        }

        public async Task<Course> Update(Course course)
        {
            var updateCourse = _courseDbContext.Courses.Update(course);
            _courseDbContext.SaveChanges();

            return await Task.FromResult(course);
        }

        public async Task<bool> Delete(int courseId)
        {
            var course = await _courseDbContext
                .Courses
                .Where(x => x.CourseId == courseId)
                .FirstOrDefaultAsync();

            _courseDbContext 
                .Courses
                .Remove(course ?? new Course());

            return _courseDbContext.SaveChanges() > 0 ? true : false;
        }
    }
}
