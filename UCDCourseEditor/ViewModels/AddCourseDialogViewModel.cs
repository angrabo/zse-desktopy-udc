using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Storage;
using UCDCourseEditor.Core.Interfaces.Repositories;

namespace UCDCourseEditor.ViewModels;

public class AddCourseDialogViewModel : ViewModelBase
{
    
    private readonly ICourseRepository _courseRepository;
    
    public AddCourseDialogViewModel(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
        AddCourseCommand = new AsyncRelayCommand(async () => await AddCourse());
    }

    public IAsyncRelayCommand AddCourseCommand { get; }
    
    private async Task AddCourse()
    {
        
    }
}