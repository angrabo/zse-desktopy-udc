using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.Core.Models;
using UCDCourseEditor.Infrastructure.Database.Data;
using UCDCourseEditor.Infrastructure.Database.Repositories;
using UCDCourseEditor.Utils;
using UCDCourseEditor.ViewModels;
using UCDCourseEditor.Views;

namespace UCDCourseEditor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public static IClassicDesktopStyleApplicationLifetime Instance { get; private set; } = null!;
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    public override async void OnFrameworkInitializationCompleted()
    {
        try
        {
            var initWindow = new PreLoadingWindow();
            initWindow.Show();
        
            var app = Host.CreateDefaultBuilder().ConfigureServices(collection =>
            {
                collection.AddDbContext<ApplicationDbContext>(options =>
                {
                    // Add creating folder in system and put db here
                    options.UseSqlite(@$"Data Source={ConfigPaths.DatabasePath}");
                });
                collection.AddSingleton<ICourseRepository, CourseRepository>();

                collection.AddSingleton<MainWindow>();
                collection.AddSingleton<PreLoadingWindow>();
                collection.AddTransient<AddCourseDialog>();
                
                collection.AddSingleton<MainWindowViewModel>();
                collection.AddSingleton<CoursesViewModel>();
                collection.AddTransient<AddCourseDialogViewModel>();
            }).Build();
            
            ServiceProvider = app.Services;

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();
#if DEBUG
#else
                await Task.Delay(3000); // taki trick aby kotka zobaczyć
#endif
      
                app.Services.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated();

                Instance = desktop;
                
                desktop.MainWindow = app.Services.GetRequiredService<MainWindow>();
                desktop.MainWindow.DataContext = app.Services.GetRequiredService<MainWindowViewModel>();
                desktop.MainWindow.Show();
                initWindow.Close();
            }

            base.OnFrameworkInitializationCompleted();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}