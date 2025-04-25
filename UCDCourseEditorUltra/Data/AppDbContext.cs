using Microsoft.EntityFrameworkCore;
using UCDCourseEditorUltra.Models.Entities;

namespace UCDCourseEditorUltra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Course> Courses { get; set; } = null!;
}