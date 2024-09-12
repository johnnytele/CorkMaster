using CorkMaster.Drawables;
using static System.Net.Mime.MediaTypeNames;

namespace CorkMaster;

public partial class WinePage : ContentPage
{
	public WinePage(Wine wine)
	{
		InitializeComponent();

        BottleView gs = (BottleView)graphic.Drawable;
        gs.wine = wine;
        graphic.Invalidate();

        nameLbl.Text = wine.DisplayTitle;
		wineryLbl.Text = wine.Winery;
        dateLbl.Text = wine.DateDrunk.ToShortDateString();
		totalScoreLbl.Text = wine.Total.ToString();
        scoreCircle.BackgroundColor = wine.BackgroundColor;

		if (wine.Notes != null)
		{
			VerticalStackLayout vs = new VerticalStackLayout();
			Label title = new Label();
			title.Text = "Notes:";
			vs.Add(title);
			Label notes = new Label();
			notes.Text = wine.Notes;
			vs.Add(notes);
            vs.Margin = 10;
            title.FontSize = 18;
            notes.FontSize = 13;
            mainStack.Add(vs);
		}

        if (wine.Location != null)
        {
            VerticalStackLayout vs = new VerticalStackLayout();
            Label title = new Label();
            title.Text = "Location:";
            vs.Add(title);
            Label text = new Label();
            text.Text = wine.Location;
            vs.Add(text);
            vs.Margin = 10;
            title.FontSize = 18;
            text.FontSize = 13;
            mainStack.Add(vs);
        }

        if (wine.Food != null)
        {
            VerticalStackLayout vs = new VerticalStackLayout();
            Label title = new Label();
            title.Text = "Food:";
            vs.Add(title);
            Label text = new Label();
            text.Text = wine.Food;
            vs.Add(text);
            vs.Margin = 10;
            title.FontSize = 18;
            text.FontSize = 13;
            mainStack.Add(vs);
        }

        if (wine.Alcohol != 0)
        {
            HorizontalStackLayout vs = new HorizontalStackLayout();
            Label title = new Label();
            title.Text = "Alcohol:";
            vs.Add(title);
            Label text = new Label();
            text.Text = wine.Alcohol.ToString() + "%";
            vs.Add(text);
            vs.Margin = 10;
            title.FontSize = 18;
            text.FontSize = 18;
            mainStack.Add(vs);
        }

    }
}