using Android.Text.Method;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
//using XLabs.Forms.Controls;
//using XLabs.Forms.Extensions;
using FacilityApp.Shared;
using FacilityAppAndroid;
using Android.Content;

[assembly: ExportRenderer(typeof(NumericEntry), typeof(NumericEntryRenderer))]
namespace FacilityAppAndroid
{
    public class NumericEntryRenderer : EntryRenderer
    {
        public NumericEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                return;
            }

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                this.Control.KeyListener = DigitsKeyListener.GetInstance(Java.Util.Locale.Default, true, true);
            }
            else
            {
                this.Control.KeyListener = DigitsKeyListener.GetInstance(true, true);
            }
        }
    }
}
