using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UCDCourseEditor.Infrastructure.Database.Data;

namespace UCDCourseEditor.Utils;

public class DatabaseValidator(ApplicationDbContext context)
{
    public bool IsDatabaseValid()
    {
        try
        {
            if (!context.Database.CanConnect())
            {
                Console.WriteLine("Cannot connect to the database.");
                return false;
            }

            var requiredTables = new[] { "Courses", "Categories" };
            var existingTables = context.Model.GetEntityTypes()
                .Select(t => t.GetTableName())
                .ToList();

            foreach (var table in requiredTables)
            {
                if (!existingTables.Contains(table))
                {
                    Console.WriteLine($"Missing required table: {table}");
                    return false;
                }
            }

            Console.WriteLine("Database is valid.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database validation failed: {ex.Message}");
            return false;
        }
    }
}