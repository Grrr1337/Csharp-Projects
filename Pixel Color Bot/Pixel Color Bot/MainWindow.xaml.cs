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
using System.Drawing; // Color, Bitmap, Graphics
using System.Windows.Forms; // Screen height and width
using MessageBox = System.Windows.MessageBox; // use the message box of the WPF
using Point = System.Windows.Point;
using System.Runtime.InteropServices; // User32.dll (and dll import)

namespace Pixel_Color_Bot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int x, int y);
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            // FullScreenAndTransparentWindow();
            // this.MouseMove += MainWindow_MouseMove;
        }

        
        private void Click()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        private void FullScreenAndTransparentWindow()
        {
            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
            this.Background= new SolidColorBrush(Colors.Transparent);
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
        }
        /* Search for a specific pixel color on screen
        - the color to search for is defined by a hex value the user enters (e.g. #ffffff)
        - include all connected screens (in case there is more than one connected monitor)
        - When a pixel with the specified color is found, take note of the x and y screen position of that pixel
        */
        private void OnButtonSearchPixelClick(object sender, RoutedEventArgs e)
        {
            string inputHexColorCode = TextBoxHexColor.Text;
            SearchPixel(inputHexColorCode);

            // MessageBox.Show(inputHexColorCode);
        }

        private bool SearchPixel (string hexcode)
        {
            // Create an empty bitmap with the size of the current screen
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap);
            // Screenshot moment -> screen content to graphics object
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            System.Drawing.Color desiredPixelColor = ColorTranslator.FromHtml(hexcode);
            // NOTE: VirtualScreen obtains information about all the connected monitors.
            for(int x = 0; x < SystemInformation.VirtualScreen.Width; x++)
            {
                for(int y = 0; y < SystemInformation.VirtualScreen.Height; y++)
                {
                    // Get the current pixel color 
                    System.Drawing.Color currentPixelColor = bitmap.GetPixel(x, y);
                    if (desiredPixelColor == currentPixelColor)
                    {
                        // MessageBox.Show(String.Format("Found Pixel at {0}, {1} - Now Set mouse cursor", x, y));
                        // Set mouse cursor and double click
                        SetCursorPos(x, y);
                        Click();
                        return true;
                    }
                }
            }

            return false;
        }// SearchPixel

        static System.Drawing.Color GetPixelColor(int x, int y)
        {
            // Create a bitmap of 1x1 pixel at the specified location
            using (Bitmap bitmap = new Bitmap(1, 1))
            {
                // Create a graphics object from the bitmap
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // Capture the screen pixel at the specified coordinates
                    graphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(1, 1));
                }

                // Get the color of the captured pixel
                return bitmap.GetPixel(0, 0);
            }
        }

        private void OnButtonSpecifyPixelClick(object sender, RoutedEventArgs e)
        {
            // Show a message box asking the user to specify a pixel
            DialogResult result = System.Windows.Forms.MessageBox.Show("Please move the mouse to the desired pixel and press ENTER/OK.",
                "Pick a Pixel", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Get the current mouse position
                System.Drawing.Point mousePosition = System.Windows.Forms.Control.MousePosition;

                // Get the color of the pixel at the mouse position
                System.Drawing.Color pixelColor = GetPixelColor(mousePosition.X, mousePosition.Y);

                // Display the color information
                System.Windows.MessageBox.Show($"Color at ({mousePosition.X}, {mousePosition.Y}): R={pixelColor.R}, G={pixelColor.G}, B={pixelColor.B}",
                    "Pixel Color", MessageBoxButton.OK, MessageBoxImage.Information);
                string hexColor = ConvertColorToHex(pixelColor);
                TextBoxHexColor.Text = hexColor;
            }
        }

        private string ConvertColorToHex(System.Drawing.Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Get the mouse position relative to the window
            Point mousePosition = e.GetPosition(this);

            // Convert to screen coordinates
            System.Windows.Point screenMousePosition = PointToScreen(new Point((int)mousePosition.X, (int)mousePosition.Y));


            // Get the color of the pixel at the mouse position
            System.Drawing.Color pixelColor = GetPixelColor((int)screenMousePosition.X, (int)screenMousePosition.Y);

            // Convert color to HEX
            string hexColor = ConvertColorToHex(pixelColor);

            TextBoxHexColor.Text = hexColor;
            // Display the color information
            //Title = $"Pixel Color: RGB({pixelColor.R}, {pixelColor.G}, {pixelColor.B}), HEX: {hexColor}";
        }
    }
}
