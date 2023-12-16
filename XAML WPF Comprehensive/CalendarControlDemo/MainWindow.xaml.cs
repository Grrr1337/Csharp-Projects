using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // myTextBlock.Text = myCalendar.SelectedDate.ToString();
            // Set the Calendar's selected date to the current date
            // myCalendar.SelectionMode = CalendarSelectionMode.SingleRange;

            // AddBlackoutDates();
            
            BlackoutWeekendDays();

            // Set the range of dates to display in the calendar
            myCalendar.DisplayDateStart = DateTime.Now;
            myCalendar.DisplayDateEnd = DateTime.Now.AddMonths(1);

            myCalendar.SelectionMode = CalendarSelectionMode.MultipleRange;

            // Single mode:
            // myCalendar.SelectionMode = CalendarSelectionMode.SingleDate;
            // myCalendar.SelectedDate = DateTime.Now; // DateTime.Today;
            // myTextBlock.Text = myCalendar.SelectedDate?.ToString("HH:mm:ss dd.MM.yyyy");

        }

        private void BlackoutWeekendDays()
        {
            // Set the range of dates you want to check
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddMonths(1);

            while (startDate <= endDate)
            {
                // Check if the current date is a weekend day (Saturday or Sunday)
                if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    // Add the weekend day to the BlackoutDates collection
                    myCalendar.BlackoutDates.Add(new CalendarDateRange(startDate));
                }

                // Move to the next day
                startDate = startDate.AddDays(1);
            }
        }

        private void AddBlackoutDates()
        {
            // Add specific dates to be blacked out
            myCalendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(5)));
            myCalendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(10), DateTime.Now.AddDays(15)));
            myCalendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddMonths(1), DateTime.Now.AddMonths(1).AddDays(5)));
        }

        // MultipleRange mode
        private void myCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myTextBlock != null)
            {
                if (myCalendar.SelectedDates.Count > 0)
                {
                    // Group selected dates into ranges
                    List<List<DateTime>> dateRanges = new List<List<DateTime>>();
                    List<DateTime> currentRange = new List<DateTime>();

                    foreach (DateTime selectedDate in myCalendar.SelectedDates)
                    {
                        if (currentRange.Count == 0 || (selectedDate - currentRange.Last()).Days == 1)
                        {
                            currentRange.Add(selectedDate);
                        }
                        else
                        {
                            dateRanges.Add(new List<DateTime>(currentRange));
                            currentRange.Clear();
                            currentRange.Add(selectedDate);
                        }
                    }

                    // Add the last range
                    if (currentRange.Count > 0)
                    {
                        dateRanges.Add(new List<DateTime>(currentRange));
                    }

                    // Now you can use dateRanges as needed
                    DisplayDateRanges(dateRanges);
                }
                else
                {
                    // Handle the case when no dates are selected
                    myTextBlock.Text = "No dates selected";
                }
            }
        }

        private void DisplayDateRanges(List<List<DateTime>> dateRanges)
        {
            StringBuilder result = new StringBuilder("Selected Ranges:\n");

            foreach (var dateRange in dateRanges)
            {
                DateTime startDate = dateRange.First();
                DateTime endDate = dateRange.Last();

                result.AppendLine($"{startDate.ToString("dd.MM.yyyy")} - {endDate.ToString("dd.MM.yyyy")}");
            }

            myTextBlock.Text = result.ToString();
        }



        /*
        // SingleRange mode:
        private void myCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myTextBlock != null)
            {
                if (myCalendar.SelectedDates.Count > 0)
                {
                    // Get the start and end dates of the selected range
                    DateTime startDate = myCalendar.SelectedDates[0];
                    DateTime endDate = myCalendar.SelectedDates[myCalendar.SelectedDates.Count - 1];

                    // Now you can use startDate and endDate as needed
                    // For example, display them in the TextBlock
                    myTextBlock.Text = $"Selected Range: {startDate.ToString("dd.MM.yyyy")} - {endDate.ToString("dd.MM.yyyy")}";
                }
                else
                {
                    // Handle the case when no dates are selected
                    myTextBlock.Text = "No dates selected";
                }
            }
        }
        */


        /*

        // Single mode:
        private void myCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myTextBlock != null)
            {
                // myTextBlock.Text = myCalendar.SelectedDate.ToString();
                myTextBlock.Text = myCalendar.SelectedDate?.ToString("HH:mm:ss dd.MM.yyyy");
            }
          
        }
        */

    }
}
