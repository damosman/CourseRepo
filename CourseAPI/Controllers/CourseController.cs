using Courses.Services.Contracts;
using Courses.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Courses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IValidator<CourseCreateReq> _validator;

        public CoursesController(ICourseService courseService, IValidator<CourseCreateReq> validator)
        {
            _courseService = courseService;
            _validator = validator;
        }

        // POST: api/courses
        [HttpPost]
        public ActionResult<BaseResponse> Create([FromBody] CourseCreateReq req)
        {
            var validationResult = _validator.Validate(req);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            Log.Information($"The {req.CourseName} course has been added to the bootcamp {DateTime.Now.Year}");
            return Ok(_courseService.Create(req));
        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<BaseResponse>> GetAllCourses()
        {
            Log.Information($"The courses are available");
            return await _courseService.GetAllCourses();
        }

        // GET: api/courses/{id}
        [HttpGet]
        [Route("{courseId}")]
        public async Task<ActionResult<BaseResponse>> GetCourse(int courseId)
        {
            Log.Information($"The course information is {@courseId}");
            return await _courseService.GetById(new CourseDto { CourseId = courseId }); ;
        }

        // PUT: api/courses/{id}
        [HttpPut]
        [Route("{courseId}")]
        public async Task<ActionResult<BaseResponse>> Update(int courseId, 
            [FromBody]CourseUpdateReq req)
        {
            Log.Information($"The course with Id:{@courseId} has been updated.");
            return await _courseService.Update(req);
        }

        // DELETE: api/courses/{id}
        [HttpDelete("{courseId}")]
        public async Task<ActionResult<BaseResponse>> DeleteCourse(int courseId)
        {
            Log.Information($"The course with Id:{@courseId} has been deleted.");
            return await _courseService.Delete(new CourseDto { CourseId = courseId });
        }
    }
}