using Courses.Services.Contracts;

namespace Courses.Services.Interfaces
{
    public interface ICourseService
    {
        CourseRsp<CourseDto> Create(CourseCreateReq req);
        Task<CourseRsp<CourseDto>> GetById(CourseDto CourseId);
        Task<CourseRsp<List<CourseDto>>> GetAllCourses();
        Task<CourseRsp<CourseDto>> Update(CourseUpdateReq req);
        Task<CourseRsp<bool>> Delete(CourseDto CourseId);
    }
}
