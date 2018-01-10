#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SampleBrowser.SfDigitalGauge;
using static SampleBrowser.SfDigitalGauge.App;

namespace SampleBrowser.SfDigitalGauge.Droid
{
    [Activity(Label = "SampleBrowser SfDigitalGauge", Icon = "@drawable/AppIcon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        double statusBarHeight, navbarheight;
        protected override void OnCreate(Bundle bundle)
        {
            int navigationResID = Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (navigationResID > 0)
            {
                navbarheight = (Resources.GetDimensionPixelSize(navigationResID) / Resources.DisplayMetrics.Density);
            }

            int statusResID = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (statusResID > 0)
            {
                statusBarHeight = (Resources.GetDimensionPixelSize(statusResID) / Resources.DisplayMetrics.Density);
            }

            SetScreenSize((Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density), (Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density));
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        void SetScreenSize(double width, double height)
        {
            App.StatusBarHeight = statusBarHeight;
            App.NavigationBarHeight = navbarheight;
            App.ScreenWidth = width;
            App.ScreenHeight = height - (statusBarHeight + navbarheight);
            App.Platform = Platforms.Android;
            App.Density = Resources.DisplayMetrics.Density;
        }
    }
}

