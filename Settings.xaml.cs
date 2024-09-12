namespace CorkMaster;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
        NavBar nav = new NavBar("Settings");
        grid.Add(nav, 0, 8);
        grid.SetColumnSpan(nav, 2);

        commentSwitch.IsToggled = Preferences.Get("Notes", true);
        dateSwitch.IsToggled = Preferences.Get("Date", true);
        foodSwitch.IsToggled = Preferences.Get("Food", true);
        locationSwitch.IsToggled = Preferences.Get("Location", true);
        alcoholSwitch.IsToggled = Preferences.Get("Alcohol", true);
    }

    private void commentSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("Notes", commentSwitch.IsToggled);
    }

    private void foodSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("Food", foodSwitch.IsToggled);
    }

    private void locationSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("Location", locationSwitch.IsToggled);
    }

    private void dateSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("Date", dateSwitch.IsToggled);
    }

    private void alcoholSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("Alcohol", alcoholSwitch.IsToggled);
    }
}