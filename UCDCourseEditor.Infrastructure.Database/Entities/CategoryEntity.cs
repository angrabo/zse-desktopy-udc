using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCDCourseEditor.Infrastructure.Database.Entities;

public class CategoryEntity : EntityBase
{
    [StringLength(128)]
    public string Name { get; set; } = null!;

    [NotMapped]
    public ICollection<CourseEntity> Courses { get; set; } = new List<CourseEntity>();
}