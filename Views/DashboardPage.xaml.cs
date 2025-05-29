

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
        int count = await _database.GetTaskCountAsync();
        TotalTasksLabel.Text = count.ToString();
    }
}