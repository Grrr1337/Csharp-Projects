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

namespace Custom_Controls_in_WPF
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
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Title = "CustomControl and UserControl practice.";
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cbToggleFan.Click += (_s, _e) =>
            {
                myCustomFanControl.FanOn = (bool)cbToggleFan.IsChecked;

            };
            lblAuthor.MouseEnter += (_s, _e) =>
            {
                lblAuthor.Content = "Vladimir Balabanov";
            };
            lblAuthor.MouseLeave += (_s, _e) =>
            {
                lblAuthor.Content = "practiced by";
            };
        }
    }
}
