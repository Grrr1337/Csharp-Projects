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

namespace StackPanelDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // I wanted to check if the partially or completely hidden buttons,
        // due to overflowing can trigger events upon clicking them
        // the answer is NO - everything happens within the main window,
        // regardless of the control overflow positioning
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Loaded += MainWindow_Loaded;
        }

        // I use it in here in order to make sure that the main window is loaded.
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Button button in FindVisualChildren<Button>(this))
            {
                button.Click += (_s, _e) => {
                    MessageBox.Show(button.Content.ToString());

                };
            }
        }

        // https://stackoverflow.com/questions/974598/find-all-controls-in-wpf-window-by-type
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }

    }
}
