using Courses.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        public override int SaveChanges()
        {
            /* this keeps the logic for setting the DateCreated and DateModified properties in one place,
            so that its consistent for all entities that might inherit it */

            var utcNow = DateTime.UtcNow; //using universal time
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is Course entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.DateCreated = utcNow;
                    }
                    entity.DateModified = utcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
