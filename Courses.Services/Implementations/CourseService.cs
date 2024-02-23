using Courses.Domain.Interfaces;
using Courses.Services.Contracts;
using Courses.Services.Extension;
using Courses.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Courses.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICoursesRepository _coursesRepository;
        public CourseService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        public CourseRsp<CourseDto> Create(CourseCreateReq req)
        {
            var newCourse = req.AsEntity();

            _coursesRepository.Add(newCourse);

            return new CourseRsp<CourseDto> 
            {
                StatusCode = "200",
                Message = "Success"
            };
        }

        public async Task<CourseRsp<bool>> Delete(CourseDto courseDto)
        {
            var result = await _coursesRepository.Delete(courseDto.CourseId);
            {
                return new CourseRsp<bool>
                {
                    StatusCode = "200",
                    Message = "Success",
                    Value = result
                };
            }
        }

        public async Task<CourseRsp<List<CourseDto>>> GetAllCourses()
        {
            var result = await _coursesRepository.GetAllCourses();

            return new CourseRsp<List<CourseDto>>
            {
                StatusCode = "200",
                Message = "Success",
                Value = result.AsDtos()
            };
        }

        public async Task<CourseRsp<CourseDto>> GetById(CourseDto courseDto)
        {
            var result = await _coursesRepository.GetById(courseDto.CourseId);

            if(result == null)
            {
                return new CourseRsp<CourseDto>
                {
                    StatusCode = "404",
                    Message = "The Course Id was not found in the database."
                };
            }
            return new CourseRsp<CourseDto>
            {
                StatusCode = "200",
                Message = "Success",
                Value = result.AsDto()
            };
        }

        public async Task<CourseRsp<CourseDto>> Update(CourseUpdateReq req)
        {
            var toUpdate = req.AsEntity();

            var update = await _coursesRepository.Update(toUpdate);

            if (update != null)
            {
                // If the update operation was successful
                return new CourseRsp<CourseDto>
                {
                    StatusCode = "200",
                    Message = "Success",
                    Value = update.AsDto()
                };
            }
            else
            {
                // If there Is an error during the update operation
                return new CourseRsp<CourseDto>
                {
                    StatusCode = "400",
                    Message = "Error updating course",
                    Value = null
                };
            }
        }
    }
}
