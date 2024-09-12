namespace CorkMaster;

public partial class WineList : ContentPage
{
    NavBar nav;
	public WineList()
	{
		InitializeComponent();
        
        nav = new NavBar("WineList");
        grid.Add(nav, 0, 2);
        DB.OpenConnection();

        if (!Preferences.ContainsKey("Notes"))
            Preferences.Set("Notes", false);
        if (!Preferences.ContainsKey("Date"))
            Preferences.Set("Date", false);
        if (!Preferences.ContainsKey("Location"))
            Preferences.Set("Location", false);
        if (!Preferences.ContainsKey("Food"))
            Preferences.Set("Food", false);
        if (!Preferences.ContainsKey("Alcohol"))
            Preferences.Set("Alcohol", false);

        filterPicker.SelectedIndex = 0;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateList();   
    }

    private void filterPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateList();
    }

    public void UpdateList()
    {
        if (filterPicker.SelectedIndex == 0)
        {
            lv.ItemsSource = (from wine in DB.conn.Table<Wine>()
                              orderby wine.DateDrunk descending
                              select wine).ToList();
        }
        else if (filterPicker.SelectedIndex == 1)
        {
            lv.ItemsSource = (from wine in DB.conn.Table<Wine>()
                              orderby wine.DateDrunk ascending
                              select wine).ToList();
        }
        else if (filterPicker.SelectedIndex == 2)
        {
            lv.ItemsSource = (from wine in DB.conn.Table<Wine>().ToList()
                              orderby wine.Total descending
                              select wine).ToList();
        }
    }

    private async void lv_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Wine wine = e.Item as Wine;
        WinePage winePage = new WinePage(wine);
        await Navigation.PushAsync(winePage, true); 
    }
}