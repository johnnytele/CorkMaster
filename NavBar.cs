using Microsoft.Maui.Layouts;
using Microsoft.Maui.Controls;

namespace CorkMaster;

public class NavBar : ContentView
{
    Button wineList = new Button();
    Button addWine = new Button();
    Button settings = new Button();


	String currentPage;
	public NavBar(string page)
	{
        currentPage = page;
		wineList.ImageSource = (currentPage == "WineList" ? "winebottleswhite.png" : "winebottlesblack.png");
		wineList.CornerRadius = 0;
		// wineList.WidthRequest = 300;
		wineList.HeightRequest = 20;
		wineList.VerticalOptions = LayoutOptions.End;
		wineList.Clicked += OnWineListClicked;
        wineList.Margin = new Thickness(-2, -2, -2, -2);
		wineList.IsEnabled = (currentPage == "WineList" ? false : true);

        addWine.ImageSource = (currentPage == "AddWine" ? "pluswhite.png" : "plusblack.png");
		addWine.HeightRequest = 70;
		addWine.WidthRequest = 70;
		addWine.CornerRadius = 35;
		addWine.BorderWidth = 2;
		addWine.Clicked += OnAddWineClicked;
		addWine.BorderColor = (currentPage == "AddWine" ? Colors.White : Colors.Black); 
		addWine.ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Top, 0);
        addWine.IsEnabled = (currentPage == "AddWine" ? false : true);



        //addWine.Padding = new Thickness(-10,0,0,0);

        settings.ImageSource = (currentPage == "Settings" ? "settingswhite.png": "settingsblack.png");
		settings.CornerRadius = 0;
		// settings.WidthRequest = 300;
		settings.HeightRequest = 20;
		settings.VerticalOptions = LayoutOptions.End;
		settings.Clicked += OnSettingsClicked;
		settings.Margin = new Thickness(-2, -2, -2, -2);
        settings.IsEnabled = (currentPage == "Settings" ? false : true);



        Grid grid = new Grid
		{
			ColumnDefinitions =
			{
				new ColumnDefinition	{Width = new GridLength(2, GridUnitType.Star)},
				new ColumnDefinition	{Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition	{Width = new GridLength(2, GridUnitType.Star)},
            }
		};

		BoxView boxView = new BoxView();
		boxView.HeightRequest = 41;
		boxView.VerticalOptions = LayoutOptions.End;
		boxView.Margin = new Thickness(-2,0, -2, 0);

        grid.Add(wineList,0,0);
		grid.Add(settings, 2, 0);
		grid.Add(boxView, 1, 0);
		grid.Add(addWine, 1, 0);
		



		grid.BackgroundColor = Color.FromRgba(0, 0, 0, 0);

		grid.Margin = new Thickness(0, -30, 0, 0);

        Content = grid;

		
	}
    private async void OnAddWineClicked(object sender, EventArgs e)
    {
		AddWine addWinePage = new AddWine();
        while (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopModalAsync();
        } 
		await Navigation.PushModalAsync(addWinePage, true);
    }
    private async void OnSettingsClicked(object sender, EventArgs e)
    {
		Settings settings = new Settings();
		/*
		if (currentPage != "WineList")
		{
            await Navigation.PopModalAsync();
        }
		*/
		await Navigation.PushModalAsync(settings, true);
    }

    private async void OnWineListClicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//WineList");
        //await Navigation.PopModalAsync();

    }

	private void changePage(string newPage)
	{
		currentPage = newPage;
	}
	
}