using Microsoft.EntityFrameworkCore;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.Core.Models;
using UCDCourseEditor.Infrastructure.Database.Data;
using UCDCourseEditor.Infrastructure.Database.Entities;

namespace UCDCourseEditor.Infrastructure.Database.Repositories;

public class CourseRepository(ApplicationDbContext context)
    : Repository<Course, CourseEntity>(context), ICourseRepository
{
    public override Task<Course> AddAsync(Course entity)
    {
        throw new NotImplementedException();
    }

    public override Task<Course> UpdateAsync(Course entity)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public override Task<Course> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public override async Task<IEnumerable<Course>> GetAllAsync()
    {
        var coursesEntities = await Context.Courses.ToListAsync();
        
        var courses = coursesEntities.Select(MapToDomain).ToList();

        return courses;
    }

    protected override CourseEntity MapToEntity(Course domain)
    {
        var courseEntity = new CourseEntity
        {
            Id = domain.Id,
            Name = domain.Name,
            Description = domain.Description,
            Credits = domain.Credits,
        };

        return courseEntity;
    }

    protected override Course MapToDomain(CourseEntity entity)
    {
        var course = new Course
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Credits = entity.Credits,
        };

        return course;
    }
}