using System.ComponentModel.DataAnnotations;

namespace UCDCourseEditorUltra.Models.Entities;

public class Course
{
    
    [Key]
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Hours { get; set; }
    
    
}