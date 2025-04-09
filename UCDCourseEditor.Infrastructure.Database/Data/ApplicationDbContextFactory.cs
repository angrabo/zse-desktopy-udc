// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
//
// namespace UCDCourseEditor.Infrastructure.Database.Data;
//
// public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
// {
//     public ApplicationDbContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//         optionsBuilder.UseSqlite(@"Data Source=C:\Users\ADMIN\Desktop\UCDCourseEditor.db");
//
//         return new ApplicationDbContext(optionsBuilder.Options);
//     }
// }