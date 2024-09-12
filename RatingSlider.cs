using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CorkMaster 
{
    public class RatingSlider : StackLayout
    {
        public RatingSlider(string rating, string description, int max)
        {
            Label title = new Label {
                Text = rating,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Start,
            };
            Label desc = new Label
            {
                Text = description,
                HorizontalTextAlignment = TextAlignment.Start,
            };
            Slider slider = new Slider
            {
                ThumbImageSource = "wineglass.png",
                Maximum = max,
                Margin = 10
            };
            HorizontalStackLayout hsl = new HorizontalStackLayout();
            hsl.Add(title);
            Children.Add(desc);
            Children.Add(slider);
        }
    }
}
