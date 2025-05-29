

using TaskManagerMobile.Services;

namespace TaskManagerMobile.Views;

public partial class DashboardPage : ContentPage
{
    private readonly DatabaseService _database;

    public DashboardPage()
    {
        InitializeComponent();
        _database = new DatabaseService();

    }

    private async void OnViewTasksClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Tasks");
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _database.Init();


        bool ShowCompletedTasks = Preferences.Get("ShowCompletedTasks", true);
        bool ShowUncompletedTasks = Preferences.Get("ShowUncompletedTasks", true);

        if (ShowCompletedTasks)
        {
            int countCompleted = await _database.GetCompletedTaskCountAsync();
            TotalCompletedTaskCountLabel.Text = countCompleted.ToString();
            TotalCompletedTaskLabel.IsVisible = true;
            TotalCompletedTaskCountLabel.IsVisible = true;
        }
        else
        {
            TotalCompletedTaskLabel.IsVisible = false;
            TotalCompletedTaskCountLabel.IsVisible = false;
        }

        if (ShowUncompletedTasks)
        {
            int countUncompleted = await _database.GetUncompletedTaskCountAsync();
            TotalUncompletedTaskCountLabel.Text = countUncompleted.ToString();
            TotalUncompletedTaskLabel.IsVisible = true;
            TotalUncompletedTaskCountLabel.IsVisible = true;
        }
        else
        {
            TotalUncompletedTaskLabel.IsVisible = false;
            TotalUncompletedTaskCountLabel.IsVisible = false;
        }


        int count = await _database.GetTaskCountAsync();
        TotalTasksLabel.Text = count.ToString();
    }
}