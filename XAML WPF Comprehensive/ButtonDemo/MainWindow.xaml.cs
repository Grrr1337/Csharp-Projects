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

namespace ButtonDemo
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
            myLabel.HorizontalAlignment = HorizontalAlignment.Center;
            myLabel.VerticalAlignment = VerticalAlignment.Top;
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            // myLabel.Foreground = Brushes.Coral;
            // Some simple logic to toggle the color
            if (myLabel.Foreground == Brushes.Coral)
            {
                myLabel.Foreground = Brushes.Black;
            }
            else if (myLabel.Foreground == Brushes.Black)
            {
                myLabel.Foreground = Brushes.Coral;
            }
            myLabel.FontSize += 1;

        }

        private void myButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You have Double Clicked!");

        }

        private void myButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.White;
            }
        }

        private void myButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.LightCoral;
            }
        }
    }
}
