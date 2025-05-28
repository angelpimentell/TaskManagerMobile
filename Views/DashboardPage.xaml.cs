namespace TaskManagerMobile.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
	}

    private async void OnViewTasksClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Tasks");
    }
}