using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using UCDCourseEditor.ViewModels;

namespace UCDCourseEditor.Views;

public partial class CoursesView : UserControl
{
    public CoursesView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<CoursesViewModel>();
    }
}