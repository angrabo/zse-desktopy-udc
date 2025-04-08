using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCDCourseEditor.Infrastructure.Database.Entities;

[Table("Courses")]
public class CourseEntity : EntityBase
{
    [StringLength(128)]
    public string Name { get; set; } = null!;
    
    [StringLength(2048)]
    public string Description { get; set; } = string.Empty;
    
    public int Credits { get; set; }
    
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    
    public CategoryEntity Category { get; set; } = null!;
}