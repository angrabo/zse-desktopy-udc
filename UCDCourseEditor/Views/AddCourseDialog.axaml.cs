using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UCDCourseEditor.ViewModels;

namespace UCDCourseEditor.Views;

public partial class AddCourseDialog : Window
{
    public AddCourseDialog(AddCourseDialogViewModel vm)
    {
        DataContext = vm;
        InitializeComponent();
    }
}