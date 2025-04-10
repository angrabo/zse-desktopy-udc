using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Microsoft.Extensions.DependencyInjection;
using UCDCourseEditor.Core.Interfaces;
using UCDCourseEditor.ViewModels;

namespace UCDCourseEditor.Views;

public partial class AddCourseDialog : Window, IDialogCloser
{
    private readonly AddCourseDialogViewModel _addCourseDialogViewModel;
    
    public AddCourseDialog()
    {
        _addCourseDialogViewModel = App.ServiceProvider.GetRequiredService<AddCourseDialogViewModel>();
        InitializeComponent();
        DataContext = _addCourseDialogViewModel;
        _addCourseDialogViewModel.DialogCloser = this;

    }

    private async void SelectImageFile_OnClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        var file = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Save Text File",
            AllowMultiple = false,
            FileTypeFilter = [new FilePickerFileType("Image files") { Patterns = ["*.png", "*.jpg", "*.jpeg"] }]
        });
        
        if (file.Count < 1) return;

        _addCourseDialogViewModel.ImagePath = file[0].Path.AbsolutePath;
    }
}