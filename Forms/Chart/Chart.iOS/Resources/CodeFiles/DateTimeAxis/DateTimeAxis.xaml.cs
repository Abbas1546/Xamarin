#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace SampleBrowser.SfChart
{
    public partial class DateTimeAxis : SampleView
    {
        int month = int.MaxValue;
        public DateTimeAxis()
        {
            InitializeComponent();

            Chart.Scroll += (sender, e) =>
            {
                month = int.MaxValue;
            };

            Chart.ZoomEnd += (sender, e) =>
            {
                month = int.MaxValue;
            };

            Chart.ZoomDelta += (sender, e) =>
            {
                month = int.MaxValue;
            };

            Chart.ZoomStart += (sender, e) =>
            {
                month = int.MaxValue;
            };

            Chart.PrimaryAxis.LabelCreated += Primary_LabelCreated;
        }

        private void Primary_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        {
            DateTime baseDate = new DateTime(1899, 12, 30);
            var date = baseDate.AddDays(e.Position);
            if (date.Month != month)
            {
                ChartAxisLabelStyle labelStyle = new ChartAxisLabelStyle();
                labelStyle.LabelFormat = "MMM-dd";
                labelStyle.Font = Font.SystemFontOfSize(9, FontAttributes.Bold);
                e.LabelStyle = labelStyle;

                month = date.Month;
            }
            else
            {
                ChartAxisLabelStyle labelStyle = new ChartAxisLabelStyle();
                labelStyle.LabelFormat = "dd";
                e.LabelStyle = labelStyle;
            }
        }
    }
}