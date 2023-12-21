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
using System.Windows.Media.Animation;
 

namespace WPF_Animations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Title = "WPF Animations";
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Focusable = true;
            this.Loaded += MainWindow_Loaded;
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
        }// public MainWindow()

        private void MainWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Begin dragging the window
                DragMove();
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnClose.Click += (_s, _e) =>
            {
                Close();
            };
            lblAuthor.MouseEnter += (_s, _e) => {
                lblAuthor.Content = "Vladimir Balabanov";
                lblAuthor.Foreground = System.Windows.Media.Brushes.Red;
            };

            lblAuthor.MouseLeave += (_s, _e) => {
                lblAuthor.Content = "Author";
                lblAuthor.Foreground = System.Windows.Media.Brushes.White;
            };

            foreach (var child in btnSet2.Children)
            {
                if (child is Button button)
                {
                    button.MouseEnter += (_s, _e) =>
                    {
                        var btn = _s as Button;
                        var widthAnimation = new DoubleAnimation() { To = 130, Duration = TimeSpan.FromSeconds(0.3) };
                        var heightAnimation = new DoubleAnimation() { To = 150, Duration = TimeSpan.FromSeconds(0.3) };

                        var colorAnimation = new ColorAnimation
                        {
                            To = Colors.MediumSlateBlue,
                            Duration = TimeSpan.FromSeconds(0.3)
                        };

                        var originalBackgroundBrush = btn.Background as SolidColorBrush;

                        if (originalBackgroundBrush != null)
                        {
                            // Create a new SolidColorBrush instance with the same color
                            var newBackgroundBrush = new SolidColorBrush(originalBackgroundBrush.Color);

                            // Apply the animation to the new SolidColorBrush
                            newBackgroundBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

                            // Set the new SolidColorBrush as the button's background
                            btn.Background = newBackgroundBrush;
                        }

                        btn.BeginAnimation(Button.WidthProperty, widthAnimation);
                        btn.BeginAnimation(Button.HeightProperty, heightAnimation);
                    }; // button.MouseEnter


                    button.MouseLeave += (_s, _e) =>
                    {
                        var btn = _s as Button;
                        var WidthAnimation = new DoubleAnimation() { To = 100, Duration = TimeSpan.FromSeconds(0.3) };
                        var HeightAnimation = new DoubleAnimation() { To = 120, Duration = TimeSpan.FromSeconds(0.3) };


                        var colorAnimation = new ColorAnimation
                        {
                            To = Colors.Transparent,
                            Duration = TimeSpan.FromSeconds(0.3)
                        };

                        var backgroundBrush = btn.Background as SolidColorBrush;

                        if (backgroundBrush != null)
                        {
                            backgroundBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                        }

                        btn.BeginAnimation(Button.WidthProperty, WidthAnimation);
                        btn.BeginAnimation(Button.HeightProperty, HeightAnimation);
                    }; // button.MouseLeave
                }
            }// foreach
        }// private void MainWindow_Loaded




    }// class
}// namespace
