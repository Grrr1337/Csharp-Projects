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

namespace SliderDemo
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
            Loaded += MainWindow_Loaded; // Preferred way
        }

        // Simple way:
        private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (myTextBlock != null) // we use this check because the window is not fully loaded
            {
                myTextBlock.Text = mySlider.Value.ToString();
            }
        }

        // Preferred way:
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Now we can be sure that all controls are loaded and can initialize the eventhandler logic
            // Add any additional initialization code here -
            // I can attach the event handlers dynamically
            // MessageBox.Show("The Main Window Has loaded!");
            //  myTextBlock2.Text = mySlider2.Value.ToString();
            mySlider2.ValueChanged += (_sender, _e) =>
            {
                // Either we can do this:
                // myTextBlock2.Text = mySlider2.Value.ToString();
                if (_sender is Slider slider)
                {
                    // Either we can do this:
                    myTextBlock2.Text = slider.Value.ToString();
                    _ = slider.Value != 0 ? myTextBlock2.FontSize = slider.Value : (object)null;

                    /*
                    // Find the TextBlock by its name
                    if (FindName("myTextBlock2") is TextBlock textBlock)
                    {
                        // Here we can refer to the Slider instance (mySlider2) using the 'slider' variable
                        // Now you can refer to the TextBlock instance (myTextBlock2) using the 'textBlock' variable
                        textBlock.Text = slider.Value.ToString();
                    }
                    */
                }
            };
        }// private void 

      
    }
}
