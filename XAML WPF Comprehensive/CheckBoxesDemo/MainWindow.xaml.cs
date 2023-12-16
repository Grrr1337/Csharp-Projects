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

namespace CheckBoxesDemo
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
            // AddCheckboxEvents(cbCheese, lblCheese);
            AddCheckboxEvents(cbMozarella, lblMozarella);
            AddCheckboxEvents(cbPeperonni, lblPeperonni);
            AddCheckboxEvents(cbPaprika, lblPaprika);
            AddCheckboxEvents(cbMushrooms, lblMushrooms);
        }

        /*
        private void cbCheese_Checked(object sender, RoutedEventArgs e)
        {
           // lblCheese.Background = Brushes.LightCoral;
        }

        private void cbCheese_Unchecked(object sender, RoutedEventArgs e)
        {
            // lblCheese.Background = Brushes.Transparent;
        }
       */


        private void AddCheckboxEvents(CheckBox checkbox, Label label)
        {
            if (checkbox != null)
            {
                checkbox.Checked += (sender, e) => Checkbox_CheckedChanged(sender, e, label);
                checkbox.Unchecked += (sender, e) => Checkbox_CheckedChanged(sender, e, label);
            }
        }

        private void Checkbox_CheckedChanged(object sender, RoutedEventArgs e, Label label)
        {
            CheckBox checkbox = (CheckBox)sender;

            if (label != null)
            {
                label.Background = checkbox.IsChecked == true ? Brushes.LightCoral : Brushes.Transparent;
            }

            // Add other logic as needed for each checkbox
        }

        private void cbParentCheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbParent.IsChecked == true);
            // cbCheese.IsChecked = newVal;
            cbMozarella.IsChecked = newVal;
            cbPeperonni.IsChecked = newVal;
            cbPaprika.IsChecked = newVal;
            cbMushrooms.IsChecked = newVal;
        }
    }
}
