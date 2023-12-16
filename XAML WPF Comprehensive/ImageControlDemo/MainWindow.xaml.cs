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

using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Interop;

namespace ImageControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<System.Drawing.Bitmap> imageList;
        private int currentImageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // SetImageSource(Properties.Resources.orange_maincoon_cat);
            /*
            imageControl.MouseUp += (sender, e) =>
            {
                MessageBox.Show("Mouse Up Event!");
            };
            */

            // Automatically populate the imageList with all resources in Properties.Resources
            imageList = Properties.Resources.ResourceManager
                .GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true)
                .Cast<System.Collections.DictionaryEntry>()
                .Where(entry => entry.Value is System.Drawing.Bitmap)
                .Select(entry => (System.Drawing.Bitmap)entry.Value)
                .ToList();

            SetImageSource(imageList[currentImageIndex]);

            imageControl.MouseUp += (sender, e) =>
            {
                // Cycle to the next image
                currentImageIndex = (currentImageIndex + 1) % imageList.Count;
                SetImageSource(imageList[currentImageIndex]);
            };

        }

        private void SetImageSource(System.Drawing.Bitmap bitmap)
        {
            try
            {
                var stream = new System.IO.MemoryStream();
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                var bitmapSource = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                imageControl.Source = bitmapSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

        private void _SetImageSource()
        {
            try
            {
                /*
                // Create a BitmapImage
                BitmapImage bitmapImage = new BitmapImage();

                // Set the image source using a relative URI
                bitmapImage.BeginInit();
                // bitmapImage.UriSource = new Uri("pack://application:,,,/Images/orange_maincoon_cat.png");
                // Source="/Images/orange_maincoon_cat.png" 
                bitmapImage.UriSource = new Uri("/Images/orange_maincoon_cat.png");
                bitmapImage.EndInit();

                // Assign the BitmapImage to the Image control
                imageControl.Source = bitmapImage;
                */


                // System.Drawing.Bitmap bmp = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().
                // GetManifestResourceStream("ImageControlDemo.Images.orange_maincoon_cat.png"));

                // Tova sraboti!
                var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(ImageControlDemo.Properties.Resources.orange_maincoon_cat.GetHbitmap(),
                                  IntPtr.Zero,
                                  Int32Rect.Empty,
                                  BitmapSizeOptions.FromEmptyOptions());

                imageControl.Source = bitmapSource;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

    }
}
