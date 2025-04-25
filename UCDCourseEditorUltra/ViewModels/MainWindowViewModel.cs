using System;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using UCDCourseEditorUltra.Extensions;

namespace UCDCourseEditorUltra.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase _currentViewModel;
    
    private readonly IServiceProvider _serviceProvider;

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentViewModel = _serviceProvider.GetRequiredService<CoursesViewModel>();
    }

    // Default constructor for design-time data
    public MainWindowViewModel()
    {
        if (!Design.IsDesignMode) return;
        var collection = new ServiceCollection();
        collection.AddAll();
        _serviceProvider = collection.BuildServiceProvider();
        CurrentViewModel = new CoursesViewModel();
    }

    [RelayCommand]
    private void NavigateToCourses()
    {
        CurrentViewModel = _serviceProvider.GetRequiredService<CoursesViewModel>();
    }

    [RelayCommand]
    private void NavigateToFiles()
    {
        CurrentViewModel = _serviceProvider.GetRequiredService<FilesViewModel>();
    }

    [RelayCommand]
    private void NavigateToMedia()
    {
        CurrentViewModel = _serviceProvider.GetRequiredService<MediaViewModel>();
    }

    public void NavigateToView<T>() where T : ViewModelBase
    {
        CurrentViewModel = _serviceProvider.GetRequiredService<T>();
    }
}