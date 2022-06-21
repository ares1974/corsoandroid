using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using WorkshopPomeriggio.Controls;
using WorkshopPomeriggio.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEntry),typeof(MyEntryRenderer))]
namespace WorkshopPomeriggio.iOS.Renderers
{
    public class MyEntryRenderer: EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.BackgroundColor = UIColor.Red;
                Control.TextColor = Color.White;
                Control.BorderStyle = UITextBorderStyle.RoundedRect;
            }
        }

    }
}