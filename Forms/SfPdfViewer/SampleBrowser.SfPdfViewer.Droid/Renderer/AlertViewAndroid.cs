#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(SampleBrowser.SfPdfViewer.Droid.AlertViewAndroid))]
namespace SampleBrowser.SfPdfViewer.Droid
{
    public class AlertViewAndroid : IAlertView
    {
        public void Show(string message)
        {
            ContentPage page = new ContentPage();
            page.DisplayAlert("",message, "Ok");
        }
    }
}
