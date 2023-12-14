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
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WPF_StackMove
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Private property to hold the opacity value
        private double WindowOpacity { get; set; }

        private Dictionary<Button, int> buttonColumnMap = new Dictionary<Button, int>();
        private int AmountOfItems = 12;
     
        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
            this.WindowOpacity = this.Opacity;
            btnAuthor.Click += (sender, e) =>
            {

                this.Opacity = 0.5;
                MessageBox.Show("" +
                    "This is a practice project, \n" + 
                    "Its purpose of the program is to simulate prompting for manual rearrangment of items" + "\n\n" +
                    "Created by: Vladimir Balabanov.\n( Grrr1337 )",
                    "Author"
                    );
                this.Opacity = this.WindowOpacity;
            };

            InitializeButtons(AmountOfItems);
        }

        private void InitializeWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.Title = "WPF Stack Move";

            var color0 = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            var color1 = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            var color2 = new SolidColorBrush(Color.FromRgb(169, 169, 169));

            // Set the background color of the main window to dark gray
            // this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Background = color1;

            // Set the background colors of the StackPanels
            // stackPanel1.Background = new SolidColorBrush(Colors.Gray);
            // stackPanel2.Background = new SolidColorBrush(Colors.Gray);
            // stackPanel3.Background = new SolidColorBrush(Colors.Gray);
            stackPanel1.Background = color2;
            stackPanel2.Background = color2;
            stackPanel3.Background = color2;

            TitleTextBlock.Foreground = color0;
            InfoTextBlock.Foreground = color0;
            btnAuthor.Foreground = color0;
        }

        private void InitializeButtons(int amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("Input only a positive amount of items!");
                return;
            }
            // Add buttons to the first StackPanel
            for (int i = 1; i <= amount; i++)
            {
                Button button = new Button
                {
                    Content = $"Item {i}",
                    Margin = new Thickness(0, 0, 0, 5),
                    ToolTip = "click on me, dude!",
                    // Width = 60, 
                    // Height = 60, 
                   
                    
                    // CornerRadius = new CornerRadius(15) // Set half of the button width to create a circle
                };


                /*
                // Block to make the button appear as a circle:
                button.Width = 60; // Set the desired width (adjust as needed)
                button.Height = 60; // Set the same value as the width to create a circle
                button.BorderThickness = new Thickness(2); // Optional: Add a border
                BorderBrush = Brushes.Black; // Optional: Set the border color
                // button.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                // button.HorizontalContentAlignment =  HorizontalAlignment.Right;

                // Set the button's template to include a Border with CornerRadius
                button.Template = CreateButtonTemplate(30);
                */


                button.Click += Button_Click;
                // button.MouseDoubleClick += Button_DoubleClick;

                stackPanel1.Children.Add(button);
                buttonColumnMap.Add(button, 0); // Initial column index is 0
            }
        }
        private ControlTemplate CreateButtonTemplate(int radius)
        {
            ControlTemplate template = new ControlTemplate(typeof(Button));

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.Name = "border";
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(radius));
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(1));
            borderFactory.SetValue(Border.BackgroundProperty, new SolidColorBrush(Colors.LightGray));

            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetBinding(ContentPresenter.ContentProperty, new System.Windows.Data.Binding("Content") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            // contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
             
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

            borderFactory.AppendChild(contentPresenterFactory);

            template.VisualTree = borderFactory;
            return template;
        }


        // Logic here is:
        /*
         * When a button is clicked once, then it moves to the next StackPanel,
         * but when a button is ctrl+clicked, then it moves to the previous StackPanel
         */

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  MoveButton(sender as Button, stackPanel1, stackPanel2);

            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    // Ctrl key is pressed
                    // MessageBox.Show("Ctrl key is pressed!");
                    string parentStackPanelName = (clickedButton.Parent as StackPanel)?.Name;
                    string StackPanelBaseName = RemoveNumericSuffix(parentStackPanelName);
                    int parentStackPanelId = GetNumericSuffix(parentStackPanelName);
                    string prevStackPanelName = StackPanelBaseName + (parentStackPanelId - 1).ToString();
                    // MessageBox.Show($"Button clicked in {parentStackPanelName}.");

                    var prevStackPanel = FindName(prevStackPanelName) as FrameworkElement;

                    if (prevStackPanel != null)
                    {
                        // MoveButton(clickedButton, (clickedButton.Parent as StackPanel), (prevStackPanel as StackPanel));
                        MoveButton(clickedButton, StackPanelBaseName, parentStackPanelId, (parentStackPanelId - 1));
                        // MessageBox.Show("Trying to move " + clickedButton.Content + " from " + parentStackPanelName + "  to " + prevStackPanelName);
                        // InfoTextBlock.Text= ("Trying to move " + clickedButton.Content + " from " + parentStackPanelName + "  to " + prevStackPanelName);
                        InfoTextBlock.Inlines.Clear();
                        InfoTextBlock.Inlines.Add(new Run { Text = "Moving ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = clickedButton.Content.ToString(), FontWeight = FontWeights.Bold });
                        InfoTextBlock.Inlines.Add(new Run { Text = " from ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = parentStackPanelName, FontWeight = FontWeights.Bold });
                        InfoTextBlock.Inlines.Add(new Run { Text = " to ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = prevStackPanelName, FontWeight = FontWeights.Bold });
                    }
                    else
                    {
                        InfoTextBlock.Inlines.Clear();
                        InfoTextBlock.Inlines.Add(new Run { Text = "Error, cannot move ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = clickedButton.Content.ToString(), FontWeight = FontWeights.Bold });
                        InfoTextBlock.Inlines.Add(new Run { Text = " to ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = prevStackPanelName, FontWeight = FontWeights.Bold });
                    }
                }
                else
                {
                    // Ctrl key is not pressed
                    // MessageBox.Show("Ctrl key is not pressed!");

                    string parentStackPanelName = (clickedButton.Parent as StackPanel)?.Name;
                    string StackPanelBaseName = RemoveNumericSuffix(parentStackPanelName);
                    int parentStackPanelId = GetNumericSuffix(parentStackPanelName);
                    string nextStackPanelName = StackPanelBaseName + (parentStackPanelId + 1).ToString();
                    // MessageBox.Show($"Button clicked in {parentStackPanelName}.");

                    var nextStackPanel = FindName(nextStackPanelName) as FrameworkElement;

                    if (nextStackPanel != null)
                    {
                        // MoveButton(clickedButton, (clickedButton.Parent as StackPanel), (nextStackPanel as StackPanel));
                        MoveButton(clickedButton, StackPanelBaseName, parentStackPanelId, (parentStackPanelId + 1));
                       

                        InfoTextBlock.Inlines.Clear();
                        InfoTextBlock.Inlines.Add(new Run { Text = "Moving ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = clickedButton.Content.ToString(), FontWeight = FontWeights.Bold });
                        InfoTextBlock.Inlines.Add(new Run { Text = " from ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = parentStackPanelName, FontWeight = FontWeights.Bold });
                        InfoTextBlock.Inlines.Add(new Run { Text = " to ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = nextStackPanelName, FontWeight = FontWeights.Bold });


                    }
                    else
                    {
                        InfoTextBlock.Inlines.Clear();
                        InfoTextBlock.Inlines.Add(new Run { Text = "Error, cannot move ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = clickedButton.Content.ToString(), FontWeight = FontWeights.Bold });
                        InfoTextBlock.Inlines.Add(new Run { Text = " to ", FontWeight = FontWeights.Normal });
                        InfoTextBlock.Inlines.Add(new Run { Text = nextStackPanelName, FontWeight = FontWeights.Bold });
                    }
                }


            }
        }

        static string RemoveNumericSuffix(string input)
        {
            // Use regular expression to remove the numeric suffix
            return Regex.Replace(input, @"\d+$", string.Empty);
        }

        static int GetNumericSuffix(string input)
        {
            // Use regular expression to extract the numeric suffix
            Match match = Regex.Match(input, @"\d+$");

            // Check if a match was found
            if (match.Success)
            {
                // Convert the matched numeric suffix to an int
                if (int.TryParse(match.Value, out int result))
                {
                    return result;
                }
            }

            // Default value if no numeric suffix is found or conversion fails
            return 0;
        }

        // private void MoveButton(Button button, string stackPanelBaseName, int sourceStackPanelID, int destinationStackPanelID)
        // Sample call: MoveButton(myButton, "stackPanel", 1, 2)
        /*
        private void MoveButton(Button button, StackPanel sourceStackPanel, StackPanel destinationStackPanel)
        {
            if (button != null && buttonColumnMap.TryGetValue(button, out int currentColumn))
            {
                int targetColumn = currentColumn + 1;
                if (targetColumn < 3)
                {
                    sourceStackPanel.Children.Remove(button);
                    destinationStackPanel.Children.Add(button);
                    buttonColumnMap[button] = targetColumn;
                }
            }
        }
        */
        private void MoveButton(Button button, string stackPanelBaseName, int sourceStackPanelID, int destinationStackPanelID)
        {
            if (button != null)
            {
                // Construct the names of source and destination StackPanels
                string sourceStackPanelName = $"{stackPanelBaseName}{sourceStackPanelID}";
                string destinationStackPanelName = $"{stackPanelBaseName}{destinationStackPanelID}";

                // Find the source and destination StackPanels by name
                var sourceStackPanel = FindName(sourceStackPanelName) as StackPanel;
                var destinationStackPanel = FindName(destinationStackPanelName) as StackPanel;

                if (sourceStackPanel != null && destinationStackPanel != null)
                {
                    // Move the button from the source to the destination StackPanel
                    sourceStackPanel.Children.Remove(button);
                    destinationStackPanel.Children.Add(button);

                    // Update the column map if needed
                    if (buttonColumnMap.TryGetValue(button, out int currentColumn))
                    {
                        int targetColumn = currentColumn + 1;
                        if (targetColumn < 3)
                        {
                            buttonColumnMap[button] = targetColumn;
                        }
                    }

                    // MessageBox.Show($"Moving {button.Content} from {sourceStackPanelName} to {destinationStackPanelName}");
                }
                else
                {
                    MessageBox.Show($"Source or destination StackPanel not found.");
                }
            }
        }

    }
}