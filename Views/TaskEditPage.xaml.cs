using TaskManagerMobile.Models;
using TaskManagerMobile.Services;

namespace TaskManagerMobile.Views;

public partial class TaskEditPage : ContentPage
{
    private readonly DatabaseService _database;
    public TaskItem TaskItem { get; set; } = new();
    public TaskEditPage()
	{
		InitializeComponent();
        _database = new DatabaseService();
        BindingContext = this;
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TaskItem.Title))
        {
            await DisplayAlert("Validation Error", "Please enter a title.", "OK");
            return;
        }

        await _database.Init();
        await _database.SaveTaskAsync(TaskItem);
        await Shell.Current.GoToAsync("//Tasks");
    }
}