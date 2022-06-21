using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopPomeriggio.Controls;
using WorkshopPomeriggio.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace WorkshopPomeriggio.Droid.Renderers
{
    public class MyEntryRenderer: EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.LightGreen);
            }
        }

        public MyEntryRenderer(Context context): base(context)
        {

        }

    }
}