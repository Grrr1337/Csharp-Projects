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

namespace DatePickerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        // Check the CalendarDemo (it is more comprehensive) 
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _ = (sender as DatePicker).SelectedDate?.ToString("HH:mm:ss dd.MM.yyyy");

            var date = (sender as DatePicker).SelectedDate;
            if (date != null)
            {

                // String myDate = date.ToString();
                String myDate = date.ToString();

                MessageBox.Show("The Date has been changed to " + myDate);
            }
        }
    }
}
