using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace CatYearsProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<System.Drawing.Bitmap> imageList;
        private int currentImageIndex = 0;
        private int inputCatAge;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Calculate Cat Age To Human age";

            this.Loaded += MainWindow_Loaded;
            /*
            // Automatically populate the imageList with all resources in Properties.Resources
            imageList = Properties.Resources.ResourceManager
                .GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true)
                .Cast<System.Collections.DictionaryEntry>()
                .Where(entry => entry.Value is System.Drawing.Bitmap)
                .Select(entry => (System.Drawing.Bitmap)entry.Value)
                .ToList();
            */
            // Sorted by filename
            imageList = Properties.Resources.ResourceManager
                .GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true)
                .Cast<System.Collections.DictionaryEntry>()
                .Where(entry => entry.Value is System.Drawing.Bitmap)
                .OrderBy(entry => entry.Key.ToString())  // Order by filename
                .Select(entry => (System.Drawing.Bitmap)entry.Value)
                .ToList();

          

        }// public MainWindow

        // define the eventhandlers of the controls in here, since we made sure that the 
        // main window has loaded
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetImageSource(imageList[currentImageIndex]);

            imageControl.MouseUp += (_sender, _e) =>
            {
                // Cycle to the next image
                currentImageIndex = (currentImageIndex + 1) % imageList.Count;
                SetImageSource(imageList[currentImageIndex]);
            };

            InputCatAge.KeyDown += (_s, _e) =>
            {
                if(_e.Key == Key.Enter)
                {
                    try
                    {
                        inputCatAge = Int32.Parse(InputCatAge.Text);
                        string resultHumanAge = "";
                        if (inputCatAge >= 0 && inputCatAge <= 1)
                        {
                            currentImageIndex = 0;
                            SetImageSource(imageList[currentImageIndex]);
                            resultHumanAge = "0-15";
                            ResultTextBlock.Text = "Your cat is " + resultHumanAge + " years old";
                        }
                        else if ( inputCatAge >= 2 && inputCatAge < 25)
                        {

                            int[] interpolatedArray = InterpolateRangeExclusive(new List<int> { 0, 32 }, 9);
                            // 4 8 12 16 20 24 28 : 9
                            int index = Array.FindIndex(interpolatedArray, age => age > inputCatAge);

                            currentImageIndex = index;
                            SetImageSource(imageList[currentImageIndex]);

                            ResultTextBlock.Text = $"Your cat is {ConvertCatAgeToHumanAge(inputCatAge)} years old";
                            // MessageBox.Show(ConvertCatAgeToHumanAge(inputCatAge).ToString());
                        }
                        else
                        {
                            ResultTextBlock.Text = "You have entered a value that is not between 0-25 \n" +
                            "Your cat must be super old!";

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Not a valid numer! Please input numeric value \n" + ex.Message);
                    }
                }
            };

        }// private void MainWindow_Loaded

        public static int[] InterpolateRangeExclusive(List<int> range, int interpolation)
        {
            if (range.Count != 2)
            {
                throw new ArgumentException("Range must contain exactly two elements: min and max.", "range");
            }

            int min = range[0];
            int max = range[1];

            if (interpolation < 2)
            {
                throw new ArgumentException("Interpolation value must be at least 2.", "interpolation");
            }

            int[] interpolatedValues = new int[interpolation - 2]; // Adjust size for exclusion
            double step = (double)(max - min) / (interpolation - 1);

            for (int i = 1; i < interpolation - 1; i++) // Start from 1 to exclude min and end before the last index to exclude max
            {
                interpolatedValues[i - 1] = (int)Math.Round(min + i * step);
            }

            return interpolatedValues;
        }


        public static int[] InterpolateRange(List<int> range, int interpolation)
        {
            if (range.Count != 2)
            {
                throw new ArgumentException("Range must contain exactly two elements: min and max.", "range");
            }

            int min = range[0];
            int max = range[1];

            if (interpolation < 2)
            {
                throw new ArgumentException("Interpolation value must be at least 2.", "interpolation");
            }

            int[] interpolatedValues = new int[interpolation];
            double step = (double)(max - min) / (interpolation - 1);

            for (int i = 0; i < interpolation; i++)
            {
                interpolatedValues[i] = (int)Math.Round(min + i * step);
            }

            return interpolatedValues;
        }

        public static int ConvertCatAgeToHumanAge(int catAge)
        {
            if (catAge < 1)
            {
                throw new ArgumentException("Cat age must be a positive integer greater than or equal to 1.", nameof(catAge));
            }

            if (catAge == 1)
            {
                return 15; // Equivalent human age for the first cat year
            }

            return (((catAge - 2) * 4) + 24);
           // return 15 + 9 * (catAge - 1);
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

    }
}
