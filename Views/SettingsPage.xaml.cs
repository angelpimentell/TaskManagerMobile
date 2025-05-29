namespace TaskManagerMobile.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ShowCompletedSwitch.IsToggled = Preferences.Get("ShowCompletedTasks", true);
        ShowUncompletedSwitch.IsToggled = Preferences.Get("ShowUncompletedTasks", true);
    }

    private void OnShowCompletedToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("ShowCompletedTasks", e.Value);
    }

    private void OnShowUncompletedToggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("ShowUncompletedTasks", e.Value);
    }

}