using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CorkMaster.ViewModels;

public class RatingViewModel : INotifyPropertyChanged {
    double appearance, color, aroma, acescence, sugar, body, flavor, astringency, overall, final = 0;
    String appearanceTxt = "Dull or Cloudy";
    String colorTxt = "Very Weak";
    String aromaTxt = "Major Flaws";
    String acescenceTxt = "For Salads";
    String sugarTxt = "Not";
    String bodyTxt = "Lacking";
    String flavorTxt = "Swill or Plonk";
    String astringencyTxt = "Harch or bitter";
    String overallTxt = "Rot Gut";
    String finalTxt = "Poor";

    public event PropertyChangedEventHandler PropertyChanged;

    public RatingViewModel() { 
        
    }

    public double Appearance
    {
        get
        {
            return appearance;
        }
        set
        {
            if (appearance != value)
            {
                appearance = Round(value);
                if (appearance <= .5)
                {
                    AppearanceTxt = "Dull or Cloudy";
                } else if (appearance <= 1.5){
                    AppearanceTxt = "Not Sharp";
                } else
                {
                    AppearanceTxt = "Clear and Brilliant";
                }
                
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string AppearanceTxt
    {
        get { return appearanceTxt; }
        set { appearanceTxt = value; OnPropertyChanged();}
    }

    public double Color
    {
        get
        {
            return color;
        }
        set
        {
            if (color != value)
            {
                color = Round(value);
                if (color <= .5)
                {
                    ColorTxt = "Very Weak";
                } else if (color <= 1.5)
                {
                    ColorTxt = "A Bit Faded";
                } else
                {
                    ColorTxt = "Appropriate";
                }
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string ColorTxt
    {
        get { return colorTxt; }
        set { colorTxt = value; OnPropertyChanged(); }
    }

    public double Aroma
    {
        get
        {
            return aroma;
        }
        set
        {
            if (aroma != value)
            {
                aroma = Round(value);
                if (aroma <= .5)
                {
                    AromaTxt = "Major Flaws";
                } else if (aroma <= 1.5)
                {
                    AromaTxt = "Flawed and Weak";
                } else if (aroma <= 2.5)
                {
                    AromaTxt = "Average";
                } else if (aroma <= 3.5)
                {
                    AromaTxt = "Excellent";
                } else
                {
                    AromaTxt = "Perfect";
                }
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string AromaTxt
    {
        get { return aromaTxt; }
        set { aromaTxt = value; OnPropertyChanged(); }
    }

    public double Acescence
    {
        get
        {
            return acescence;
        }
        set
        {
            if (acescence != value)
            {
                acescence = Round(value);
                if (acescence <= .5)
                {
                    AcescenceTxt = "For Salads";
                } else if (acescence <= 1.5)
                {
                    AcescenceTxt = "Slight";
                } else
                {
                    AcescenceTxt = "None and Clean";
                }
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string AcescenceTxt
    {
        get { return acescenceTxt; }
        set { acescenceTxt = value; OnPropertyChanged(); }
    }
    public double Sugar
    {
        get
        {
            return sugar;
        }
        set
        {
            if (sugar != value)
            {
                sugar = Round(value);
                if (sugar <= 1.5)
                {
                    SugarTxt = "Not";
                } else
                {
                    SugarTxt = "Appropriate";
                }
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string SugarTxt
    {
        get { return sugarTxt; }
        set { sugarTxt = value; OnPropertyChanged(); }
    }
    public double Body
    {
        get
        {
            return body;
        }
        set
        {
            if (body != value)
            {
                body = Round(value);
                if (body <= 1.5)
                {
                    BodyTxt = "Lacking";
                } else
                {
                    BodyTxt = "Good Feel";
                }
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string BodyTxt
    {
        get { return bodyTxt; }
        set { bodyTxt = value; OnPropertyChanged(); }
    }

    public double Flavor
    {
        get
        {
            return flavor;
        }
        set
        {
            if (flavor != value)
            {
                flavor = Round(value);
                if (flavor <= .5)
                {
                    FlavorTxt = "Swill or Plonk";
                } else if (flavor <= 1.5)
                {
                    FlavorTxt = "Mid-Quality";
                } else
                {
                    FlavorTxt = "Balanced and Rich";
                }
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string FlavorTxt
    {
        get { return flavorTxt; }
        set { flavorTxt = value; OnPropertyChanged(); }
    }
    public double Astringency
    {
        get
        {
            return astringency;
        }
        set
        {
            if (astringency != value)
            {
                astringency = Round(value);
                if (astringency <= .5)
                {
                    AstringencyTxt = "Harsh or Bitter";
                } else if (astringency <= 1.5)
                {
                    AstringencyTxt = "A Bit Rough";
                } else
                {
                    AstringencyTxt = "Balanced Tannins";
                }
                OnPropertyChanged();
                updateTotal();
            }
        }
    }

    public string AstringencyTxt
    {
        get { return astringencyTxt; }
        set { astringencyTxt = value; OnPropertyChanged(); }
    }
    public double Overall
    {
        get
        {
            return overall;
        }
        set
        {
            if (overall != value)
            {
                overall = Round(value);
                if (overall <= .5)
                {
                    OverallTxt = "Rot Gut";
                } else if (overall <= 1.5)
                {
                    OverallTxt = "Average";
                } else
                {
                    OverallTxt = "Top Rank";
                }
                updateTotal();
                OnPropertyChanged();
            }
        }
    }

    public string OverallTxt
    {
        get { return overallTxt; }
        set { overallTxt = value; OnPropertyChanged(); }
    }

    public double Final
    {
        get
        {
            return final;
        }
        set
        {

                final = Round(value);
                if (final <= 14)
                {
                    FinalTxt = "Poor";
                }
                else if (final <= 14.7)
                {
                    FinalTxt = "Below Average";
                }
                else if (final <= 16.7)
                {
                    FinalTxt = "Average to Good";
                }
                else if (final <= 18.7)
                {
                    FinalTxt = "Great and Classic";
                }
                OnPropertyChanged();
            
        }
    }

    public string FinalTxt
    {
        get { return finalTxt; }
        set { finalTxt = value; OnPropertyChanged(); }
    }
    public void updateTotal()
    {
        final = appearance + color + aroma + acescence + sugar 
            + body + flavor + astringency + overall;
        Final = Round(final);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    double Round(double value)
    {
        return (double)Math.Round(value, 1);
    }
}
