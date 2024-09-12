using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using System.Drawing;

namespace CorkMaster;

[Table("wine")]
public class Wine
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string WineName { get; set; }
    public string? Winery { get; set; }
    public int Vintage { get; set; }
    public string Color { get; set; }
    public string Grape { get; set; }
    public double Appearance { get; set; }
    public double ColorGrade { get; set; }
    public double Aroma { get; set; }
    public double Acescence { get; set; }
    public double SugarDryness { get; set; }
    public double Body { get;set; }
    public double Flavor { get; set; }
    public double Astringency { get; set; }
    public double Overall { get; set; }
    public string? Notes { get; set; }
    public DateTime DateDrunk { get; set; }
    public string? Food { get; set; }
    public string? Location { get; set; }
    public double Alcohol { get; set; }
    public Microsoft.Maui.Graphics.Color BackgroundColor
    {
        get
        {
            switch (this.Color)
            {
                case "Red": return Microsoft.Maui.Graphics.Color.FromHex("#B11226");
                default: return Microsoft.Maui.Graphics.Color.FromHex("#FFEBC8");
            }
        }
    }

    public double Total
    {
        get
        {
            double total = Appearance + ColorGrade + Aroma + Acescence + SugarDryness
            + Body + Flavor + Astringency + Overall;
            return (double)Math.Round(total, 1);
        }
    }

    public string DisplayTitle
    {
        get
        {
            string vintage = Vintage.ToString();

            if (vintage.Length >= 2)
            {
                return WineName + " " + vintage.Substring(vintage.Length - 2) + "'";
            } else
            {
                return WineName;
            }
        }
    }
}

