using System.Collections.ObjectModel;
using System.Linq;
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
        var enumerable = courses.ToList();
        var descendingCourses = enumerable.OrderByDescending(c => c.Id);
        Courses = new ObservableCollection<Course>(descendingCourses);
        IsLoading = false;
    }
    
    public async Task LoadCoursesWithoutLoadingAsync()
    {
        var courses = await _courseRepository.GetAllAsync();
        var enumerable = courses.ToList();
        var descendingCourses = enumerable.OrderByDescending(c => c.Id);
        Courses = new ObservableCollection<Course>(descendingCourses);
    }
}