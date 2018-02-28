#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
	public class LineSeriesViewModel
	{

		public ObservableCollection<ChartDataModel> LineData1 { get; set; }

		public ObservableCollection<ChartDataModel> LineData2 { get; set; }
		public LineSeriesViewModel()
		{
			LineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2005", 60),
				new ChartDataModel("2006", 42),
				new ChartDataModel("2007", 62),
				new ChartDataModel("2008", 82),
				new ChartDataModel("2009", 84),
				new ChartDataModel("2010", 98),
				new ChartDataModel("2011", 85)
			};

			LineData2 = new ObservableCollection<ChartDataModel>
			{
                new ChartDataModel("2005", 30),
                new ChartDataModel("2006", 12),
                new ChartDataModel("2007", 32),
                new ChartDataModel("2008", 52),
                new ChartDataModel("2009", 54),
                new ChartDataModel("2010", 68),
                new ChartDataModel("2011", 55)
			};
		}
	}
}