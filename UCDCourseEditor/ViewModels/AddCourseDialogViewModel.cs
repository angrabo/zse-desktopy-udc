using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Storage;
using UCDCourseEditor.Core.Interfaces;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.Views;

namespace UCDCourseEditor.ViewModels;

public partial class AddCourseDialogViewModel : ViewModelBase
{
    
    private readonly ICourseRepository _courseRepository;
    public           IDialogCloser     DialogCloser { get; set; }
    
    [ObservableProperty] private string _courseName;
    [ObservableProperty] private string _courseDescription;
    [ObservableProperty] private string _imagePath;
    [ObservableProperty] private bool _isAdded;


    public AddCourseDialogViewModel()
    {
    }

    public AddCourseDialogViewModel(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
        AddCourseCommand = new AsyncRelayCommand(async () => await AddCourse());
    }

    public IAsyncRelayCommand AddCourseCommand      { get; }
    
    private async Task AddCourse()
    {
        
        var course = new Core.Models.Course
        {
            Name = CourseName,
            Description = CourseDescription,
            ImagePath = ImagePath,
            CategoryId = 1
            
        };

        await _courseRepository.AddAsync(course);
        
        DialogCloser.Close();
    }
    
}