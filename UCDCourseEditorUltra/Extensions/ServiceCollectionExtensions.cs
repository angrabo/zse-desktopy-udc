using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCDCourseEditorUltra.Data;
using UCDCourseEditorUltra.Utils;
using UCDCourseEditorUltra.ViewModels;

namespace UCDCourseEditorUltra.Extensions;

public static class ServiceCollectionExtensions
{
    public static void  AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<FilesViewModel>();
        services.AddTransient<ViewModels.CoursesViewModel>();
        services.AddTransient<MediaViewModel>();
        services.AddTransient<MainWindowViewModel>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite($"Data Source={ConfigPaths.DatabasePath}");
        });
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        
    }

    public static void AddAll(this IServiceCollection services)
    {
        AddRepositories(services);
        AddServices(services);
        AddViewModels(services);
    }
}