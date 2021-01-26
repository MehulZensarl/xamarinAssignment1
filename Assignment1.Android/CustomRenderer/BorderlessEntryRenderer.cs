using System;
using Android.Content;
using Assignment1.CustomControls;
using Assignment1.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace Assignment1.Droid.CustomRenderer
{
    public class BorderlessEntryRenderer: EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {

        }
        public static void Init() { }
        double fontSize;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        
        }
    }
}
