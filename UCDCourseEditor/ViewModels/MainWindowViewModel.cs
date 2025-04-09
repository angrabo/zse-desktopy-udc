using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UCDCourseEditor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly CoursesViewModel _coursesViewModel;

    [ObservableProperty] private object _currentViewModel;

    public MainWindowViewModel(CoursesViewModel coursesViewModel)
    {
        _coursesViewModel = coursesViewModel;
        NavigateCoursesCommand = new AsyncRelayCommand(LoadCoursesViewAsync);
        _currentViewModel = this;
    }

    public IAsyncRelayCommand NavigateCoursesCommand { get; }

    private Task LoadCoursesViewAsync(CancellationToken cancellationToken)
    {
        CurrentViewModel = _coursesViewModel;
        _ = Task.Run(async () => await _coursesViewModel.LoadCoursesAsync(), cancellationToken);
        return Task.CompletedTask;
    }
}