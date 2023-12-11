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

namespace WPFHelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vladimir has clicked the button!");
            myLabel.Content = "Label content modified by Vlado!";
        }

        /*
            To dynamically add a new button to the XAML when a button is clicked, 
            you can programmatically create a new Button element in the code-behind and add it to the StackPanel or another container in your XAML. 
            Here's an example:
        */

        private void BtnAddProgramatically_Click(object sender, RoutedEventArgs e)
        {
            // Creating a new button
            Button newButton = new Button();
            newButton.Content = "New Button";
            newButton.Click += NewButton_Click;
            // Adding the new button to the StackPanel
            ((StackPanel)this.Content).Children.Add(newButton);
        }
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Button Clicked!");
        }
    }
}
