using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.ViewModels;

namespace UCDCourseEditor.Views;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly CoursesViewModel _coursesViewModel;
    
    public MainWindow()
    {
        InitializeComponent();
        _mainWindowViewModel = App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        _coursesViewModel = App.ServiceProvider.GetRequiredService<CoursesViewModel>();
        DataContext = _mainWindowViewModel;
        _mainWindowViewModel.NavigateCoursesCommand.Execute(_coursesViewModel);
    }
    

    private async void AddCourseButton_OnCLick(object? sender, RoutedEventArgs e)
    {
        var addCourseDialog = new AddCourseDialog();
        await addCourseDialog.ShowDialog(this);
        _ = Task.Run(async () =>
        {
            await _coursesViewModel.LoadCoursesWithoutLoadingAsync();
        });

    }
}