using Courses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Courses.Repositories.Data
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Applicant>()
                .Property(l => l.ExistingDevSkill)
                .HasConversion(
                    eds => string.Join(",", eds),
                    dbVal => dbVal.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()
                    )
                );

            modelBuilder
                .Entity<Applicant>()
                .Property(l => l.EmploymentStatus)
                .HasConversion(
                    es => string.Join(",", es),
                    dbVal => dbVal.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()
                    )
                );
        }

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
