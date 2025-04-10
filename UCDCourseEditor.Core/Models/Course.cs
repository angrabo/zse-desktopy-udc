namespace UCDCourseEditor.Core.Models;

public class Course : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public string Instructor { get; set; }
    public int CategoryId { get; set; }

}