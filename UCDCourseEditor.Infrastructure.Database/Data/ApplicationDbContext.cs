using Microsoft.EntityFrameworkCore;
using UCDCourseEditor.Infrastructure.Database.Entities;

namespace UCDCourseEditor.Infrastructure.Database.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
}