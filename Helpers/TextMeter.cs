using Size = Microsoft.Maui.Graphics.Size;

namespace MauiLab
{
    public partial class TextMeter
    {
        //private Typeface textTypeface;

        public Size MeasureTextSize(string text, double width, double fontSize, string fontName = null)
        {
            //var density = global::Android.App.Application.Context.Resources!.DisplayMetrics!.Density;

            //using var localTextView = new TextView(global::Android.App.Application.Context)
            //{
            //    Typeface = GetTypeface(fontName)
            //};
            //localTextView.SetText(text, TextView.BufferType.Normal);
            //localTextView.SetTextSize(ComplexUnitType.Sp, (float)fontSize);

            //int widthMeasureSpec = global::Android.Views.View.MeasureSpec.MakeMeasureSpec(
            //    (int)(width * density), MeasureSpecMode.AtMost);
            //int heightMeasureSpec = global::Android.Views.View.MeasureSpec.MakeMeasureSpec(
            //    0, MeasureSpecMode.Unspecified);

            //localTextView.Measure(widthMeasureSpec, heightMeasureSpec);

            //return new Size(((double)localTextView.MeasuredWidth / density) + 5, ((double)localTextView.MeasuredHeight / density) + 5);
            return new Size(1000);
        }

        //private Typeface GetTypeface(string fontName)
        //{
        //    if (fontName == null)
        //    {
        //        return Typeface.Default;
        //    }

        //    if (textTypeface == null)
        //    {
        //        textTypeface = Typeface.Create(fontName, TypefaceStyle.Normal);
        //    }

        //    return textTypeface;
        //}
    }
}