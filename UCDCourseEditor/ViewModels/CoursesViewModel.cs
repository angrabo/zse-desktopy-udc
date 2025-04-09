using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.Core.Models;

namespace UCDCourseEditor.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly ICourseRepository _courseRepository;

    [ObservableProperty]
    private ObservableCollection<Course> _courses;

    [ObservableProperty]
    private bool _isLoading;

    public CoursesViewModel(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
        _courses = new ObservableCollection<Course>();
    }

    public async Task LoadCoursesAsync()
    {
        if (IsLoading)
            return;
        IsLoading = true;
        var courses = await _courseRepository.GetAllAsync();
        Courses = new ObservableCollection<Course>(courses);
        IsLoading = false;
    }
}