using Courses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder
            .Property(a => a.CourseId)
            .IsRequired()
            .HasMaxLength(3);

        builder
            .Property(a => a.CourseName)
            .IsRequired()
            .HasColumnType("nvarchar(50)");

        builder
            .Property(a => a.CourseDescription)
            .IsRequired()
            .HasColumnType("nvarchar(100)");

        builder
            .Property(a => a.DateCreated)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(a => a.DateModified)
            .ValueGeneratedOnUpdate()
            .IsRequired();
    }
}