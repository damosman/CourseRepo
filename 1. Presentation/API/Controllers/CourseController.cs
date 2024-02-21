using Courses.Entities;
using Courses.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Courses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesDbContext _context;

        public CoursesController(CoursesDbContext context, ILogger<CoursesController>  logger)
        {
            _context = context;
        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            var Courses = courses.Select(c => new Course { Id = c.Id, Name = c.Name }).ToList();
            Log.Information($"The courses available are {@Courses}");
            return Ok(Courses);
        }

        // GET: api/courses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id, Exception exception)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                Log.Error(exception: exception, $"The {@course} is not available, Try again.");
                return NotFound();
            }

            Log.Information($"The course information is {@course}");
            return Ok(course); ;
        }

        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            Log.Information($"A new {@course} has been added to the bootcamp");
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        // PUT: api/courses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                Log.Error($"The id:{@id} is incorrect, Enter a valid course id again.");
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    Log.Error($"The id:{@id} cannot be found, Enter the course id again.");
                    return NotFound();
                }
                else
                {
                    Log.Information($"The {@course} has been updated.");
                    throw;
                }
            }

            Log.Information($"The {@course} is not updated.");
            return NoContent();
        }

        // DELETE: api/courses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                Log.Error($"The id:{@id} cannot be found, Enter the course id again.");
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            Log.Information($"The {@course} has been deleted.");
            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}