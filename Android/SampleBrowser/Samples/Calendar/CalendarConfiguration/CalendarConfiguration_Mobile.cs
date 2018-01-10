#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Calendar;
using Com.Syncfusion.Calendar.Enums;
using Android.Graphics;
using Java.Util;
using Android.Text.Format;
using Java.Text;

namespace SampleBrowser
{
	public class CalendarConfiguration_Mobile
	{
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        SelectionMode selectioMode = SelectionMode.SingleSelection;
        LinearLayout.LayoutParams minMaxSeparatorLayoutParam;  
        LinearLayout.LayoutParams underMaxSeparatorLayoutParam;
        DatePickerDialog minDatePicker, maxDatePicker;
		LinearLayout propertylayout;
		FrameLayout mainView;
        Button minDateButton, maxDateButton;
        private Calendar minPick, maxPick;
        TextView spaceAdder2, maxDate;
        SeparatorView underMaxSeparator;
        ArrayAdapter<String> dataAdapter;
        SeparatorView minMaxSeparator;
        TextView spaceAdder1, minDate;
        const int DATE_DIALOG_ID = 0;                           
        SfCalendar calendar;
        Spinner modeSpinner;
        Context context;
        TextView viewModetxt;
        int width;
   
        public View GetSampleContent (Context con)
		{
			context = con;
            /************
             **Calendar**
             ************/
            MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
			labelSettings.DateLabelSize = 14;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.MonthViewLabelSetting = labelSettings;
            monthViewSettings.TodayTextColor = Color.ParseColor("#1B79D6");
            monthViewSettings.InlineBackgroundColor = Color.ParseColor("#E4E8ED");
            monthViewSettings.CurrentMonthTextColor = (Color.ParseColor("#F7F7F7"));
            monthViewSettings.WeekDayBackgroundColor=Color.ParseColor("#464646");
            monthViewSettings.WeekDayTextColor = Color.ParseColor("#F9F9F9");
            monthViewSettings.PreviousMonthTextColor = Color.ParseColor("#BFBFBF");
            monthViewSettings.PreviousMonthBackgroundColor = Color.ParseColor("#F9F9F9");

            //Calendar Inizializatation
            calendar = new SfCalendar (con);
			calendar.ShowEventsInline = false;
			calendar.HeaderHeight = 100;
			calendar.ViewMode = ViewMode.MonthView;           
            calendar.MonthViewSettings = monthViewSettings;
            calendar.DrawMonthCell += calendar_DrawMonthCell;

            //main View
			mainView = new FrameLayout(con);
            mainView.AddView (calendar);
			return mainView;
		}

       

        public View GetPropertyWindowLayout (Context co)
		{
			context = co;
			width = (context.Resources.DisplayMetrics.WidthPixels) / 2;

            ViewmodeLayout();
            MinimumDateLayout();
            MaximumDateLayout();

           /******************
            **propertylayout**
            ******************/
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
            propertylayout.AddView(viewModetxt);
            propertylayout.AddView(modeSpinner);
            propertylayout.AddView(spaceAdder1);
            propertylayout.AddView(minDate);
            propertylayout.AddView(minDateButton);
            //propertylayout.AddView(minMaxSeparator, minMaxSeparatorLayoutParam);
            propertylayout.AddView(spaceAdder2);
            propertylayout.AddView(maxDate);
            propertylayout.AddView(maxDateButton);
            //propertylayout.AddView (underMaxSeparator,underMaxSeparatorLayoutParam);
            propertylayout.SetPadding(10, 10, 10, 10);

            return propertylayout;
		}

       
        private void ViewmodeLayout()
        {
            /************
            **ViewMode**
            ************/
            viewModetxt = new TextView(context);
            viewModetxt.TextSize = 20;
            viewModetxt.Text = "Selection Mode";
            modeSpinner = new Spinner(context,SpinnerMode.Dialog);

            //Selection List
            List<String> selectionList = new List<String>();
            selectionList.Add("Single Selection");
            selectionList.Add("Multiple Selection");

            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, selectionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            modeSpinner.Adapter = dataAdapter;

            //Mode Spinner Item Changed Listener
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Single Selection"))
                {
                    selectioMode = SelectionMode.SingleSelection;
                }
                if (selectedItem.Equals("Multiple Selection"))
                {
                    selectioMode = SelectionMode.MultiSelection;
                }
                
            };
        }
      
        private void MinimumDateLayout()
        {
            /****************
            **Minimum Date**
            ****************/
            spaceAdder1 = new TextView(context);
            minPick = Calendar.Instance;
            minPick.Set(2012, 0, 1);
            maxPick = Calendar.Instance;
            maxPick.Set(2018, 11, 1);

            //Minimum Date Text
            minDate = new TextView(context);
            minDate.Text = "Min Date";
            minDate.TextSize = 20;
            minDate.Gravity = GravityFlags.Left;

            //minDateButton
            minDateButton = new Button(context);
            minDateButton.SetBackgroundColor(Color.ParseColor("#8CD4CF"));
            minDateButton.Text = "1/1/2012";
            minDateButton.TextSize = 16;
            minDatePicker = new DatePickerDialog(context, MinDateSetting, 2012, 1, 1);
            minDateButton.Click += (object sender, EventArgs e) => {
                minDatePicker.Show();
            };

            //Separator 1
            minMaxSeparator = new SeparatorView(context, width * 2);
            minMaxSeparator.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            minMaxSeparatorLayoutParam = new LinearLayout.LayoutParams(width * 2, 5);
            minMaxSeparatorLayoutParam.SetMargins(0, 20, 0, 0);
        }

     
        private void MaximumDateLayout()
        {

            /****************
             **Maximum Date**
             ****************/
            spaceAdder2 = new TextView(context);
            maxDate = new TextView(context);
            maxDate.Text = "Max Date";
            maxDate.TextSize = 20;
            maxDate.Gravity = GravityFlags.Left;

            //maxDateButton
            maxDateButton = new Button(context);
            maxDateButton.Text = "1/12/2018";
            maxDateButton.TextSize = 16;
            maxDateButton.SetBackgroundColor(Color.ParseColor("#8CD4CF"));
            maxDatePicker = new DatePickerDialog(context, MaxDateSetting, 2018, 12, 1);
            maxDateButton.Click += (object sender, EventArgs e) => {
                maxDatePicker.Show();
            };

            //Separator 1
            underMaxSeparator = new SeparatorView(context, width * 2);
            underMaxSeparator.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            underMaxSeparatorLayoutParam = new LinearLayout.LayoutParams(width * 2, 5);
            underMaxSeparatorLayoutParam.SetMargins(0, 20, 0, 0);
        }
        /*******************************
         **Minimum DateSelect Method**
         *******************************/
        void MinDateSetting (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			DateTime newMinDate = e.Date;

			Calendar minCal = Calendar.Instance;
			minCal.Set (newMinDate.Year, newMinDate.Month-1, newMinDate.Day);

			if (calendar.MaxDate == null || (calendar.MaxDate != null && minCal.Before (calendar.MaxDate))) {
				calendar.MinDate = minCal;
				StringBuilder stringBuilder = new StringBuilder ().Append (newMinDate.Day).Append ("/").Append (newMinDate.Month).Append ("/").Append (newMinDate.Year);
				minDateButton.Text = stringBuilder.ToString ();
			}
		}

        /*******************************
         **Maximum DateSelect Method**
         *******************************/
        void MaxDateSetting (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			DateTime newMaxDate = e.Date;
			Calendar maxCal = Calendar.Instance;
			maxCal.Set (newMaxDate.Year, newMaxDate.Month-1, newMaxDate.Day);
			if (calendar.MinDate == null || (calendar.MinDate != null && maxCal.After (calendar.MinDate))) {				
				calendar.MaxDate = maxCal;
				StringBuilder stringBuilder = new StringBuilder ().Append (newMaxDate.Day).Append ("/").Append (newMaxDate.Month ).Append ("/").Append (newMaxDate.Year);
				maxDateButton.Text = stringBuilder.ToString ();
			}
		}
       
        /************************
         **Apply Changes Method**
         ************************/      
        public void ApplyChanges ()
		{
			calendar.SelectionMode = selectioMode;
		}

        /************************
         **DrawMonthCell Method**
         ************************/
        void calendar_DrawMonthCell(object sender, SfCalendar.DrawMonthCellEventArgs e)
        {
            SimpleDateFormat compareString = new SimpleDateFormat("dd/MM/yyyy");
            String temp = new SimpleDateFormat("dd/MM/yyyy").Format(e.P1.Date.Time);
            Java.Util.Date date = compareString.Parse(temp);
            string dayString = new SimpleDateFormat("EEEE").Format(date);
            if (dayString.ToLower().Equals("sunday")|| dayString.ToLower().Equals("saturday"))
            {
                e.P1.TextColor = Color.ParseColor("#0990e9");
                e.P1.FontAttribute = (int)TypefaceStyle.Bold;
            }            
            else
            {
                e.P1.TextColor = Color.ParseColor("#7F7F7F");
                e.P1.FontAttribute = (int)TypefaceStyle.Italic;
            }
        }
    }
}
