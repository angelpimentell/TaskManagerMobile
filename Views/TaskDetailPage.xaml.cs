using TaskManagerMobile.Models;
using TaskManagerMobile.Services;

namespace TaskManagerMobile.Views;

public partial class TaskDetailPage : ContentPage
{
    private readonly DatabaseService _database = new();

    public TaskDetailPage()
	{
		InitializeComponent();
	}

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (BindingContext is TaskItem task)
        {
            bool confirm = await DisplayAlert("Confirm", "Delete this task?", "Yes", "No");
            if (confirm)
            {
                await _database.Init();
                await _database.DeleteTaskAsync(task);
                await Shell.Current.GoToAsync("//Tasks");
            }
        }
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        if (BindingContext is TaskItem task)
        {
            var editPage = new TaskEditPage();
            editPage.TaskItem = task;
            editPage.TaskItem.Title = task.Title;
            editPage.TaskItem.Description = task.Description;
            editPage.BindingContext = editPage;
            await Navigation.PushAsync(editPage);
        }
    }
}