using Courses.Services.Contracts;
using Courses.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Courses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IValidator<CourseCreateReq> _validator;
        private readonly ILogger _logger;

        public CoursesController(ICourseService courseService, IValidator<CourseCreateReq> validator, ILogger logger)
        {
            _courseService = courseService;
            _validator = validator;
            _logger = logger;
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
            _logger.Information($"The {req.CourseName} course has been added to the bootcamp {DateTime.Now.Year}");
            Log.Information($"The {req.CourseName} course has been added to the bootcamp {DateTime.Now.Year}");
            return Ok(_courseService.Create(req));
        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<BaseResponse>> GetAllCourses()
        {
            _logger.Information($"The courses are available");
            Log.Information($"The courses are available");
            return await _courseService.GetAllCourses();
        }

        // GET: api/courses/{id}
        [HttpGet]
        [Route("{courseId}")]
        public async Task<ActionResult<BaseResponse>> GetCourse(int courseId)
        {
            _logger.Information($"The course information is {@courseId}");
            Log.Information($"The course information is {@courseId}");
            return await _courseService.GetById(new CourseDto { CourseId = courseId }); ;
        }

        // PUT: api/courses/{id}
        [HttpPut]
        [Route("{courseId}")]
        public async Task<ActionResult<BaseResponse>> Update(int courseId, 
            [FromBody]CourseUpdateReq req)
        {
            _logger.Information($"The course with Id:{@courseId} has been updated.");
            Log.Information($"The course with Id:{@courseId} has been updated.");
            return await _courseService.Update(req);
        }

        // DELETE: api/courses/{id}
        [HttpDelete("{courseId}")]
        public async Task<ActionResult<BaseResponse>> DeleteCourse(int courseId)
        {
            _logger.Information($"The course with Id:{@courseId} has been deleted.");  
            Log.Information($"The course with Id:{@courseId} has been deleted.");
            return await _courseService.Delete(new CourseDto { CourseId = courseId });
        }
    }
}