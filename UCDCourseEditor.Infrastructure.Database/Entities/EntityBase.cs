using System.ComponentModel.DataAnnotations;

namespace UCDCourseEditor.Infrastructure.Database.Entities;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}