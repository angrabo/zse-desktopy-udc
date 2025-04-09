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
    public MainWindow(ICourseRepository courseRepository)
    {
        InitializeComponent();
    }

    public MainWindow()
    {
        throw new NotImplementedException();
    }

    private void AddCourseButton_OnCLick(object? sender, RoutedEventArgs e)
    {
        var addCourseDialog = new AddCourseDialog(App.ServiceProvider.GetRequiredService<AddCourseDialogViewModel>());
        addCourseDialog.ShowDialog(this);
    }
}