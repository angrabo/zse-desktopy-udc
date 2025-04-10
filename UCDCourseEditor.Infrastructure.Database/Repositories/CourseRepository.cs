﻿using Microsoft.EntityFrameworkCore;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.Core.Models;
using UCDCourseEditor.Infrastructure.Database.Data;
using UCDCourseEditor.Infrastructure.Database.Entities;

namespace UCDCourseEditor.Infrastructure.Database.Repositories;

public class CourseRepository(ApplicationDbContext context)
    : Repository<Course, CourseEntity>(context), ICourseRepository
{
    protected override CourseEntity MapToEntity(Course domain)
    {
        var courseEntity = new CourseEntity
        {
            Id = domain.Id,
            Name = domain.Name,
            Description = domain.Description,
            ImagePath = domain.ImagePath,
            CategoryId = domain.CategoryId
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
            ImagePath = entity.ImagePath,
            CategoryId = entity.CategoryId
        };

        return course;
    }
}