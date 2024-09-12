using System;
using System.Reflection;
using System.IO;
using Microsoft.Maui.Graphics;

namespace CorkMaster.Drawables;


public class BottleView : IDrawable
{

    public Wine wine { get; set; }
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float W = dirtyRect.Width;
        float H = dirtyRect.Height;

        canvas.StrokeColor = wine.BackgroundColor;
        canvas.FillColor = wine.BackgroundColor;
        /*
        float percentFilled = ((float)wine.Astringency / 2f);
        float barSize = percentFilled * 40;
        float startSpot = 40 - barSize;
        
        canvas.FillRectangle(0, startSpot, 10, barSize);
        */
        DrawABox(canvas, dirtyRect, (float)wine.Appearance,     2f, 0,   "Appearance");
        DrawABox(canvas, dirtyRect, (float)wine.ColorGrade,     2f, 70,  "Color");
        DrawABox(canvas, dirtyRect, (float)wine.Aroma,          4f, 140, "Aroma");
        DrawABox(canvas, dirtyRect, (float)wine.Acescence,      2f, 210, "Acescence");
        DrawABox(canvas, dirtyRect, (float)wine.SugarDryness,   2f, 280, "Sugar");
        DrawABox(canvas, dirtyRect, (float)wine.Body,           2f, 350, "Body");
        DrawABox(canvas, dirtyRect, (float)wine.Flavor,         2f, 420, "Flavor");
        DrawABox(canvas, dirtyRect, (float)wine.Astringency,    2f, 490, "Astringency");
        DrawABox(canvas, dirtyRect, (float)wine.Overall,        2f, 560, "Overall");

    }

    public void DrawABox(ICanvas canvas, RectF dirtyRect, float score, float maxScore, float startingY, string name)
    {
        startingY += 3;
        canvas.FontSize = 15;
        float percentFilled = (score / maxScore);
        float barSize = percentFilled * 275;

        canvas.FillRectangle(0, startingY + 10, barSize, 50);
        canvas.DrawString(name, 5, startingY + 6, HorizontalAlignment.Left);
        canvas.FontSize = 20;
        canvas.DrawString(score.ToString(), barSize - 18, startingY + 40, HorizontalAlignment.Center);
    }
}