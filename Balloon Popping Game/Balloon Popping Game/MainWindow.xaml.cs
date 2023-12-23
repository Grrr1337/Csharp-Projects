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
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace Balloon_Popping_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        int speed = 130;
        int intervals = 90; // how often the game is going to create new ballooons
        Random rand = new Random();
        List<Rectangle> itemRemover = new List<Rectangle>();

        private Image scopeImage;

        ImageBrush backgroundImage = new ImageBrush();
        int balloonSkins;
        int amount;
        int missedBalloons;
        bool gameIsActive;
        int score;
        // MediaPlayer player = new MediaPlayer();
        System.Media.SoundPlayer player = new SoundPlayer();
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Title = "Pop the baloons";
            this.ResizeMode = System.Windows.ResizeMode.CanMinimize;
            this.Focusable = true;
            this.Focus();
            this.Loaded += MainWindow_Loaded;
        }// public MainWindow()

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/background-Image2.png"));
            canvas.Background = backgroundImage;

            Canvas.SetZIndex(lblScore, 3);
            Canvas.SetZIndex(lblMiss, 3);

            // This doesn't work:
            // Canvas.SetLeft(lblMiss, Canvas.GetLeft(lblScore));
            // Canvas.SetTop(lblMiss, Canvas.GetTop(lblScore) - 200);

            this.KeyDown += (_s, _e) => // close the game upon pressing space or enter
            {
                if (_e.Key == Key.Space || _e.Key == Key.Enter)
                {
                    // Close the window
                    Close();
                }
            };

            InitializeCursor();

            RestartGame();

           

            gameTimer.Tick += (_s, _e) => // GameEngine
            {
                lblScore.Content = "Score: " + score;
                lblMiss.Content = "Missed: " + missedBalloons;

                intervals -= 10;

                if (intervals < 1)
                {
                    ImageBrush balloonImage = new ImageBrush();
                    balloonSkins++;
                    if (balloonSkins > 5)
                    {
                        balloonSkins = 1;
                    }

                    string baseUri = "pack://application:,,,/Resources/balloon";

                    // Use a for-loop to generate the image source based on the skin value
                    for (int i = 1; i <= 5; i++)
                    {
                        if (balloonSkins == i)
                        {
                            balloonImage.ImageSource = new BitmapImage(new Uri($"{baseUri}{i}.png")); // {i:D2}
                            break;
                        }
                    }// for 

                    // Generate a random double in the range of 1.0 to 1.5
                    double sizeMultplier = (rand.NextDouble() * 0.5 + 1.0);

                    Rectangle newBalloon = new Rectangle
                    {
                        Tag = "balloon",
                        Height = rand.Next(55, 65) * sizeMultplier,
                        Width = rand.Next(55, 65) * sizeMultplier,
                        Fill = balloonImage,
                    };
                    Canvas.SetLeft(newBalloon, rand.Next(50, 400));

                    Canvas.SetTop(newBalloon, 600);
                    Canvas.SetZIndex(newBalloon, 2);

                    canvas.Children.Add(newBalloon);
                    intervals = rand.Next(90, 150);

                }// if  (intervals < 1)

                foreach (Rectangle rec in canvas.Children.OfType<Rectangle>())
                {
                    if ("balloon" == (string)rec.Tag)
                    {
                        amount = rand.Next(-5, 5);
                        Canvas.SetTop(rec, Canvas.GetTop(rec) - speed);
                        Canvas.SetLeft(rec, Canvas.GetLeft(rec) - (amount * -1));

                    }
                    if (Canvas.GetTop(rec) < 0) // top offset for disappearing balloons
                    {
                        itemRemover.Add(rec);
                        missedBalloons++;
                    }
                }// foreach 

                foreach (Rectangle rec in itemRemover)
                {
                    canvas.Children.Remove(rec);
                }// foreach

                if (missedBalloons > 10)
                {
                    gameIsActive = false;
                    gameTimer.Stop();
                    // MessageBox.Show("Game over!");
                    AnimateGameOver("Game Over", 2500); // 1500 = 1.5 seconds
                }
            }; // gameTimer.Tick // GameEngine

            canvas.MouseLeftButtonDown += async (_s, _e) => // PopBalloons
            {
                if (gameIsActive)
                {
                    if (_e.OriginalSource is Rectangle)
                    {
                        Debug.WriteLine("Hit!");
                        Rectangle activeRect = (Rectangle)_e.OriginalSource;
                        // player.Open(new Uri("/Resources/pop_sound.mp3", UriKind.RelativeOrAbsolute));
                        // player.Play();

                        // Get the resource path dynamically
                        string resourceName = GetResourcePath("pop_sound.wav");
                        Debug.WriteLine(resourceName);

                        // Play sound from embedded resource asynchronously
                         await PlayEmbeddedResourceSoundAsync(resourceName);
                        //  await PlayEmbeddedResourceSoundAsync("Balloon_Popping_Game.Resources.pop_sound.wav");

                        // Trigger the pop animation
                        PopBalloonAnimation(activeRect);

                        canvas.Children.Remove(activeRect);
                        score++;
                    }
                }// if (gameIsActive) 

            }; // canvas.MouseLeftButtonDown

            /*
            player.MediaOpened += (_s, _e) =>
            {
                // Media opened successfully, play the sound.
                player.Play();
            };
            player.MediaFailed += (_s, _e) =>
            {
                // Handle media failed event (e.ErrorException will contain details).
                MessageBox.Show("Media failed to open: " + _e.ErrorException.Message);
            };
            */

        }// private void MainWindow_Loaded

 
        private void PopBalloonAnimation(Rectangle balloon)
        {
            ImageBrush popBalloonImage = new ImageBrush();
            popBalloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/pop_balloon.png"));

            // Create an Image control for the pop balloon image
            Image popBalloon = new Image
            {
                Source = popBalloonImage.ImageSource,
                Width = balloon.Width,
                Height = balloon.Height,
                Opacity = 1.0
            };

            // Position the pop balloon image at the same location as the original balloon
            Canvas.SetLeft(popBalloon, Canvas.GetLeft(balloon));
            Canvas.SetTop(popBalloon, Canvas.GetTop(balloon));
            Canvas.SetZIndex(popBalloon, 1); // Set a higher ZIndex to ensure it's above other elements

            // Add the pop balloon image to the canvas
            canvas.Children.Add(popBalloon);

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 1.0, // Initial scale
                To = 0.0,   // Final scale
                Duration = TimeSpan.FromSeconds(1.0), // Adjust the duration as needed
                AutoReverse = false // Set to true if you want the animation to reverse
            };

            // Set up an event handler for when the animation completes
            animation.Completed += (sender, e) =>
            {
                // Remove the balloon from the canvas after the animation is complete
                // canvas.Children.Remove(balloon);

                // Remove both the original balloon and the pop balloon image
                canvas.Children.Remove(balloon);
                canvas.Children.Remove(popBalloon);

            };

            // Apply the animation to the balloon's ScaleTransform
            // ScaleTransform scaleTransform = new ScaleTransform();
            // balloon.RenderTransform = scaleTransform;
            // scaleTransform.CenterX = balloon.Width / 2;
            // scaleTransform.CenterY = balloon.Height / 2;
            // balloon.RenderTransformOrigin = new Point(0.5, 0.5);
            // scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            // scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
            // 
            // Apply the opacity animation to the pop balloon image
            popBalloon.BeginAnimation(UIElement.OpacityProperty, animation);
        
        }// PopBalloonAnimation



        private void AnimateGameOver(string text, int millisecondsDelay)
        {


            // Create a label
            Label lostLabel = new Label
            {
                Content = text,
                FontSize = 56,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 100, // Set a specific height for vertical alignment
                Opacity = 0 // Start with 0 opacity
            };
            // Add the label to the main canvas
            canvas.Children.Add(lostLabel);

            // Calculate the position to center the label within the MainWindow
            double left = (this.ActualWidth) * 0.5;
            double top = (this.ActualHeight) * 0.5;

            // Set the position
            // Canvas.SetLeft(lostLabel, (left - lostLabel.ActualWidth * 0.5) - (this.Width * 0.5)); // - (this.Width * 0.25));
            Canvas.SetLeft(lostLabel, (left - lostLabel.ActualWidth * 0.5) - (this.Width * 0.35));
            Canvas.SetTop(lostLabel, (this.ActualHeight * 0.35));
            Canvas.SetZIndex(lostLabel, 2);

            // Create an animation to fade in and out the label
            DoubleAnimation fadeInOutAnimation = new DoubleAnimation
            {
                From = 0, // Start with 0 opacity
                To = 1,   // End with full opacity
                AutoReverse = true, // Enable auto-reverse (fade out)
                Duration = TimeSpan.FromMilliseconds(millisecondsDelay) // Total animation duration
            };

            // Set up the completed event handler to remove the label after the animation
            fadeInOutAnimation.Completed += async (sender, e) =>
            {
                // Add a delay before calling ResetGame
                await Task.Delay(TimeSpan.FromMilliseconds(200));
                canvas.Children.Remove(lostLabel);

                // Call ResetGame
                // ResetGame();
            };

            // Apply the animation to the label's opacity property
            lostLabel.BeginAnimation(UIElement.OpacityProperty, fadeInOutAnimation);

            // textBlock.BeginAnimation(UIElement.OpacityProperty, fadeInOutAnimation);

        }// AnimateGameOver();


        private void InitializeCursor()
        {
            scopeImage = new Image
            {
                Name = "scopeImage",
                Height = 30,
                Width = 30,
                Source = new BitmapImage(new Uri(("pack://application:,,,/Resources/aim2.png"))),
                Stretch = System.Windows.Media.Stretch.Fill, // Adjust stretch mode as needed
            };
            // scopeImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/aim.png"));
            scopeImage.IsHitTestVisible = false;
            Canvas.SetLeft(scopeImage, 360);
            Canvas.SetTop(scopeImage, 314);
            Canvas.SetZIndex(scopeImage, 999); // Set the ZIndex for Canvas
                                               // Add the image to the Canvas or another container
            canvas.Children.Add(scopeImage);
            // Hide the mouse cursor
            this.Cursor = Cursors.None;

            canvas.MouseMove += (_s, _e) => //  
            {
                Point position = _e.GetPosition(this);
                double px = position.X;
                double py = position.Y;
                Canvas.SetLeft(scopeImage, px - (scopeImage.Width * 0.5));
                Canvas.SetTop(scopeImage, py - (scopeImage.Height * 0.5));

            }; //  canvas.MouseMove
        }// private void InitializeCursor

        private string GetResourcePath(string fileName)
        {
            // Get the assembly containing the embedded resource
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get the default namespace of the assembly
            string defaultNamespace = assembly.GetName().Name;
            // Replace spaces with underscores
            defaultNamespace = defaultNamespace.Replace(" ", "_");

            // Get the full name of the assembly, which includes the namespace
            // string assemblyFullName = assembly.GetName().FullName;
            // Extract the namespace from the full name
            // string defaultNamespace2 = assemblyFullName.Substring(0, assemblyFullName.IndexOf('.'));


            Debug.WriteLine(defaultNamespace);
            // Debug.WriteLine(defaultNamespace2);

            // Combine the namespace, folder path, and file name
            string resourcePath = $"{defaultNamespace}.Resources.{fileName}";

            return resourcePath;
        }// private string GetResourcePath


        // private void PlayEmbeddedResourceSound(string resourceName)
        private async Task PlayEmbeddedResourceSoundAsync(string resourceName)
        {
            try
            {
                // Get the assembly containing the embedded resource
                Assembly assembly = Assembly.GetExecutingAssembly();

                // Load the sound file from the embedded resource
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    
                    if (stream != null)
                    {
                        // Play the sound synchronously
                        // player.Stream = stream;
                        // player.PlaySync(); // Play synchronously to avoid issues

                        // Play the sound asynchronously
                        await Task.Run(() => player.Stream = stream);
                        player.Play(); // This line is not awaited intentionally
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing sound: " + ex.Message);
            }
        }// private void PlayEmbeddedResourceSound


        private void StartGame()
        {
            gameTimer.Start();
            missedBalloons = 0;
            score = 0;
            intervals = 90;
            gameIsActive = true;
            speed = 3;
        }//   private void StartGame()
        private void RestartGame()
        {
            foreach (Rectangle rec in canvas.Children.OfType<Rectangle>())
            {
                itemRemover.Add(rec);
            }
            foreach (Rectangle rec in itemRemover)
            {
                canvas.Children.Remove(rec);
            }
            itemRemover.Clear();
            StartGame();
        }//  private void RestartGame()



    }// public partial class MainWindow : Window

}// namespace Balloon_Popping_Game
