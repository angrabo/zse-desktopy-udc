using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using UCDCourseEditorUltra.Data;
using UCDCourseEditorUltra.Models.Entities;

namespace UCDCourseEditorUltra.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly AppDbContext _dbContext;
    private const    int          PageSize = 20;

    [ObservableProperty] private ObservableCollection<Course> _courses = new();
    [ObservableProperty] private bool                         _isLoading;
    [ObservableProperty] private int                          _currentPage = 1;
    [ObservableProperty] private int                          _totalPages  = 1;
    [ObservableProperty] private bool                         _hasNextPage;
    [ObservableProperty] private bool                         _hasPreviousPage;

    public CoursesViewModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadCoursesCommand.Execute(null);
    }

    public CoursesViewModel()
    {
        // Default constructor for design-time data
        _dbContext = new AppDbContext(new DbContextOptions<AppDbContext>());
    }

    [RelayCommand]
    private async Task LoadCourses()
    {
        await LoadCoursePage(1);
    }

    [RelayCommand]
    private async Task LoadCoursePage(int pageNumber)
    {
        if (pageNumber < 1) return;

        IsLoading = true;

        // Calculate total count and pages on background thread
        var (totalCount, coursesPage) = await Task.Run(() =>
        {
            var count = _dbContext.Courses.Count();
            var items = _dbContext.Courses
                .AsNoTracking()
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            return (count, items);
        });

        // Update pagination information
        TotalPages = (totalCount + PageSize - 1) / PageSize;
        CurrentPage = pageNumber;
        HasNextPage = CurrentPage < TotalPages;
        HasPreviousPage = CurrentPage > 1;

        // Create a new collection and assign it in one operation
        Courses = new ObservableCollection<Course>(coursesPage);

        IsLoading = false;
    }

    [RelayCommand]
    private Task NextPage()
    {
        if (HasNextPage)
        {
            return LoadCoursePage(CurrentPage + 1);
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    private Task PreviousPage()
    {
        if (HasPreviousPage)
        {
            return LoadCoursePage(CurrentPage - 1);
        }

        return Task.CompletedTask;
    }
}