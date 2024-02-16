using Courses.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
    }
}
