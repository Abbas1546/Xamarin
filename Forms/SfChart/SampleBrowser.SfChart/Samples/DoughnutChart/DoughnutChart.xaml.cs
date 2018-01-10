#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class DoughnutChart : SampleView
	{
		public DoughnutChart()
		{
			InitializeComponent();
			if (!(Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS))
			{
				Chart.Series[0].AnimationDuration = 2;
			}
		}
	}
}
