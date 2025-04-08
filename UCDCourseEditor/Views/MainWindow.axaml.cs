using System;
using Avalonia.Controls;
using UCDCourseEditor.Core.Interfaces.Repositories;

namespace UCDCourseEditor.Views;

public partial class MainWindow : Window
{
    
    private readonly ICourseRepository _courseRepository;
    public MainWindow(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
        
        var c = _courseRepository.GetAllAsync().Result;
        foreach (var co in c)
        {
            Console.WriteLine(co.Name);
        }
        
        InitializeComponent();
    }
}