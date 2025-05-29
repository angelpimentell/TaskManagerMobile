using TaskManagerMobile.Models;
using TaskManagerMobile.ViewModels;

namespace TaskManagerMobile.Views;


public partial class TaskListPage : ContentPage
{
	public TaskListPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is TasksViewModel vm)
        {
            vm.LoadTasks();
        }
    }
    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Task selected");

        if (e.CurrentSelection.FirstOrDefault() is TaskItem selectedTask)
        {
            await Navigation.PushAsync(new TaskDetailPage
            {
                BindingContext = selectedTask
            });
        }

    ((CollectionView)sender).SelectedItem = null;
    }
}
