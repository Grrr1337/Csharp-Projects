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

namespace GridDemo
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
            AttachButtonClickHandlers();
        }

        private void AttachButtonClickHandlers()
        {
            // Get all the buttons in the grid
            IEnumerable<Button> buttons = GetAllButtons();

            // Attach the common event handler to each button
            foreach (Button button in buttons)
            {
                button.Click += Button_Click;
            }
        }

        private IEnumerable<Button> GetAllButtons()
        {
            // Use LINQ to find all buttons in the grid
            return myGrid.Children.OfType<Button>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the clicked button
            Button clickedButton = (Button)sender;

            // Get the row and column of the clicked button
            int row = Grid.GetRow(clickedButton);
            int column = Grid.GetColumn(clickedButton);

            // Display the location information
            MessageBox.Show($"Button {row}{column} clicked!");
        }

    }
}
