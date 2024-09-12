
using CorkMaster.ViewModels;
using SQLite;

namespace CorkMaster;

public partial class AddWine : ContentPage
{
    Entry locationEntry, foodEntry, alcoholEntry;
    Editor notesEntry;
    DatePicker datePicker;

    public AddWine()
	{
        InitializeComponent();
        NavBar nav = new NavBar("AddWine");

        if (Preferences.Get("Date", true))
        {
            datePicker = new DatePicker();
            datePicker.Date = DateTime.Now;
            topStack.Add(datePicker);
        }

        if (Preferences.Get("Location", true))
        {
            locationEntry = new Entry();
            locationEntry.WidthRequest = 170;
            locationEntry.HorizontalTextAlignment = TextAlignment.Center;
            locationEntry.Placeholder = "Location Tasted";
            topStack.Add(locationEntry);
        }

        if (Preferences.Get("Notes", true))
        {
            notesEntry = new Editor();
            notesEntry.Placeholder = "Wine Notes";
            notesEntry.HeightRequest = 100;
            bottomStack.Add(notesEntry);
        }

        if (Preferences.Get("Food", true))
        {
            foodEntry = new Entry();
            foodEntry.Placeholder = "Food Eaten With This Wine";
            foodEntry.HeightRequest = 40;
            bottomStack.Add(foodEntry);
        }

        if (Preferences.Get("Alcohol", true))
        {
            alcoholEntry = new Entry();
            alcoholEntry.Placeholder = "Alc %";
            alcoholEntry.Margin = new Thickness(50, 0, 0, 0);
            colorAndAlc.Add(alcoholEntry);
        }



        grid.Add(nav, 0, 1);
        DB.OpenConnection();
        DB.conn.CreateTable<Wine>();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        string colorOfWine = "Red";
        if (colorType.IsToggled)
        {
            colorOfWine = "White";
        }
        int year;
        int.TryParse(vintage.Text, out year);
        Wine wine = new Wine
        {
            WineName = wineName.Text,
            Vintage = year,
            Winery = winery.Text,
            Color = colorOfWine,
            Aroma = aroma.Value,
            Appearance = appearance.Value,
            ColorGrade = color.Value,
            Acescence = acescence.Value,
            SugarDryness = sugar.Value,
            Body = body.Value,
            Flavor = flavor.Value,
            Astringency = astringency.Value,
            Overall = overall.Value,
            DateDrunk = DateTime.Now,
        };

        if (Preferences.Get("Location", true))
        {
            wine.Location = locationEntry.Text;
        }

        if (Preferences.Get("Notes", true))
        {
            wine.Notes = notesEntry.Text;
        }

        if (Preferences.Get("Date", true))
        {
            wine.DateDrunk = datePicker.Date;
        }
        if (Preferences.Get("Food", true))
        {
            wine.Food = foodEntry.Text;
        }
        if (Preferences.Get("Alcohol", true))
        {
            wine.Alcohol = double.Parse(alcoholEntry.Text);
        }

        DB.conn.Insert(wine);
        Shell.Current.GoToAsync("//WineList");
    }

    private void colorType_Toggled(object sender, ToggledEventArgs e)
    {
        if (colorType.IsToggled)
        {
            colorLabel.Text = "White";
        } else
        {
            colorLabel.Text = "Red";
        }
    }
}