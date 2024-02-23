using Courses.Entities;
using Courses.Services.Contracts;

namespace Courses.Services.Extension
{
    public static class CourseExtensions
    {
        public static Course AsEntity(this CourseCreateReq req)
        {
            return new Course
            {
                CourseId = req.CourseId,
                CourseName = req.CourseName,
                CourseDescription = req.CourseDescription,
                CreatedBy = Environment.UserName,
                DateCreated = DateTime.UtcNow,
            };
        }

        public static Course AsEntity(this CourseUpdateReq req)
        {
            return new Course
            {
                Id = req.Id,
                CourseId = req.CourseId,
                CourseName = req.CourseName,
                CourseDescription = req.CourseDescription,
                CreatedBy = Environment.UserName,
                ModifiedBy = Environment.UserName,
                DateModified = DateTime.UtcNow,
            };
        }

        public static CourseDto AsDto(this Course entity)
        {
            return new CourseDto
            {
                Id = entity.Id,
                CourseId = entity.CourseId,
                CourseName = entity.CourseName,
                CourseDescription = entity.CourseDescription
            };
        }
        public static List<CourseDto> AsDtos(this List<Course> entities)
        {
            var courseDtos = new List<CourseDto>();

            foreach (Course entity in entities)
            {
                courseDtos.Add(entity.AsDto());
            }

            return courseDtos;
        }
    }
}
