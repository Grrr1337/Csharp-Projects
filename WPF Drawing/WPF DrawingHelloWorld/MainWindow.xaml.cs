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


// https://github.com/IanMcT/GraphicsUsingWPF/tree/master

namespace WPF_DrawingHelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<(string Name, string DefaultHeader)> menuItemDataList;
        private double moveDistance = 5;
        private bool isDragging = false;
        private Point offset;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Title = "WPF Drawing";
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Focusable = true;
            this.Focus();
            this.Loaded += MainWindow_Loaded;
        }// public MainWindow
        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize menuItemDataList - used to dynamically assign the Header values based on the Name
            menuItemDataList = new List<(string Name, string DefaultHeader)>
            {
                ("menuDrawRectangle", "Draw a _Rectangle"),
                ("menuDrawRedRectangle", "Draw a Red Rectangle"),
                ("menuSetCircle", "Draw a _Circle"),
                ("menuCheckerboard", "Draw a C_heckerboard"),
                ("menuFunky", "Draw _Funky"),
                ("menuLines", "Draw _Lines"),
                ("menuRandomLines", "Draw _Random Lines"),
                ("menuText", "Draw _Text")

            };

            // MenuItem foundMenuItem = FindInVisualTreeDown(this, typeof(System.Windows.Controls.MenuItem)) as MenuItem;
            // MessageBox.Show(FindVisualChildren2<MenuItem>(this).Count<MenuItem>().ToString());
            // MessageBox.Show(FindVisualChildren2<MenuItem>(this).ToString());

            // Find the Menu in the visual tree

            Menu menu = FindInVisualTreeDown(this, typeof(Menu)) as Menu;

            if (null == menu)
            {
                throw new Exception("The Menu object is null!");
            }

            // Find the top-level MenuItem
            MenuItem topLevelMenuItem = menu.Items.OfType<MenuItem>().FirstOrDefault();

            if (null == topLevelMenuItem)
            {
                throw new Exception("The topLevelMenuItem object is null!");
            }

           
            // MessageBox.Show(FindVisualChildren2<MenuItem>(FindVisualChildren2<MenuItem>(this).First()).ToString());

            // foreach (MenuItem mi in FindVisualChildren2<MenuItem>(FindVisualChildren2<MenuItem>(this).First()))
            // foreach (MenuItem mi in FindInVisualTreeDown(typeof(MainWindow), typeof(System.Windows.Controls.MenuItem))

            // Menu menu2 = FindInVisualTreeDown(this, typeof(Menu)) as Menu;
            // foreach (MenuItem mi in FindVisualChildren2<MenuItem>(menu2))

            foreach (MenuItem mi in topLevelMenuItem.Items.OfType<MenuItem>())
            {
                // MessageBox.Show(mi.Name);

                var menuItemData = menuItemDataList.FirstOrDefault(data => data.Name == mi.Name);
                if (menuItemData != default)
                {
                    // Set the Header value dynamically
                    mi.Header = menuItemData.DefaultHeader;
                }

                switch (mi.Name.ToString())
                {
                    case "menuDrawRectangle":
                        mi.Click += (_s, _e) => {
                            canvas.Children.Clear();

                            Rectangle blueRect = new Rectangle();
                            blueRect.Fill = Brushes.Blue;
                            blueRect.Width = 100;
                            blueRect.Height = 100;

                            canvas.Children.Add(blueRect);

                            // Calculate the position to center the rectangle
                            double left = (canvas.ActualWidth - blueRect.Width) / 2;
                            double top = (canvas.ActualHeight - blueRect.Height) / 2;

                            Canvas.SetTop(blueRect, top);
                            Canvas.SetLeft(blueRect, left);



                            Label label = new Label
                            {
                                Content = "Press [W/A/S/D] to move me\n[Q/E] to adjust the speed...",
                                FontFamily = new FontFamily("Verdana"),
                                FontWeight = FontWeights.Normal,
                                FontSize = 12,
                                Foreground = Brushes.Black,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                            };
                            canvas.Children.Add(label);

                            double xleft = (this.ActualWidth) * 0.5;
                            double xtop = (this.ActualHeight) * 0.5;

                            // Set the position
                            Canvas.SetLeft(label, (xleft - label.ActualWidth * 0.5) - (this.Width * 0.25));
                            Canvas.SetTop(label, (xtop - label.ActualHeight * 0.5));
                            

                            //Canvas.SetTop(label, (canvas.ActualHeight * 0.5));
                            //Canvas.SetLeft(label, (canvas.ActualWidth * 0.5));

                            this.PreviewKeyDown += (_sender, _keyEventArgs) => {
                                if (null == blueRect)
                                {
                                    return;
                                }
                                // double moveDistance = 10;

                                switch (_keyEventArgs.Key)
                                {
                                    case Key.W:
                                        Canvas.SetTop(blueRect, Canvas.GetTop(blueRect) - moveDistance);
                                        break;
                                    case Key.A:
                                        Canvas.SetLeft(blueRect, Canvas.GetLeft(blueRect) - moveDistance);
                                        break;
                                    case Key.S:
                                        Canvas.SetTop(blueRect, Canvas.GetTop(blueRect) + moveDistance);
                                        break;
                                    case Key.D:
                                        Canvas.SetLeft(blueRect, Canvas.GetLeft(blueRect) + moveDistance);
                                        break;
                                    case Key.Q:
                                        moveDistance += 5;
                                        break;
                                    case Key.E:
                                        {
                                            moveDistance += -5;
                                            if(moveDistance <= 0)
                                            {
                                                moveDistance = 5;
                                            }
                                            break;
                                        }
                                    case Key.Enter:
                                    case Key.Space:
                                        { // some dummy logic of creating an invisible button and trying to remove this parent callback,
                                            // but it attaches another lambda callback instead.
                                            // Create an invisible button
                                            Button invisibleButton = new Button
                                            {
                                                Content = "InvisibleButton",
                                                Visibility = Visibility.Collapsed
                                            };
                                            // Add a click event handler to remove the PreviewKeyDown event
                                            invisibleButton.Click += (__sender, __e) => {
                                                MessageBox.Show("Invisible button clicked!");
                                                // this.PreviewKeyDown -= MainWindow_PreviewKeyDown;
                                                this.PreviewKeyDown += (___s, ___e) => {
                                                    // MessageBox.Show("Apparently I didn't overwrite the callback");
                                                    moveDistance += 5;
                                                };

                                            };
                                            // Simulate a click on the invisible button
                                            invisibleButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

                                            // Remove the invisible button
                                            // Note: You might want to remove the button after a delay or at a specific point in your logic
                                            // to ensure the click event is processed before removing the button.
                                            canvas.Children.Remove(invisibleButton);
                                            if (!canvas.Children.Contains(invisibleButton))
                                            {
                                                MessageBox.Show("Invisible button does not exist.");
                                            }
                                            break;
                                        }
                                    // Remove the event handler
                                    default:
                                        break;
                                }
                            };

                        };
                        break;
                    case "menuDrawRedRectangle":
                        mi.Click += (_s, _e) => {
                            canvas.Children.Clear();
                            Rectangle redRect = new Rectangle();
                            redRect.Fill = Brushes.Red;
                            redRect.Width = 100;
                            redRect.Height = 100;

                            canvas.Children.Add(redRect);
                            Canvas.SetBottom(redRect, 0);
                            Canvas.SetRight(redRect, 0);

                        };
                        break;
                    case "menuSetCircle":
                        mi.Click += (_s, _e) => {
                            canvas.Children.Clear();

                            Ellipse circle = new Ellipse();
                            circle.Fill = Brushes.Black;

                            circle.Width = 100;
                            circle.Height = 100;

                            canvas.Children.Add(circle);

                            Canvas.SetLeft(circle, canvas.ActualWidth / 2 - circle.Width / 2);
                            Canvas.SetTop(circle, canvas.ActualHeight / 2 - circle.Height / 2);
                        };
                        break;
                    case "menuCheckerboard":
                        mi.Click += (_s, _e) => {
                            canvas.Children.Clear();
                            int squareWidth;
                            if (canvas.ActualWidth > canvas.ActualHeight)
                            {
                                squareWidth = (int)(canvas.ActualHeight / 8);
                            }
                            else
                            {
                                squareWidth = (int)(canvas.ActualWidth / 8);
                            }

                            for (int row = 0; row < 8; row++)
                            {
                                for (int col = 0; col < 8; col++)
                                {
                                    Rectangle r = new Rectangle();
                                    if ((row + col) % 2 == 0)
                                    {
                                        r.Fill = Brushes.Gray;
                                    }
                                    else
                                    {
                                        r.Fill = Brushes.PeachPuff;
                                    }
                                    r.Width = squareWidth;
                                    r.Height = squareWidth;
                                    canvas.Children.Add(r);
                                    Canvas.SetLeft(r, col * squareWidth);
                                    Canvas.SetTop(r, row * squareWidth);
                                }
                            }
                        
                        };
                        break;
                    case "menuFunky":
                        mi.Click += (_s, _e) => {
                            canvas.Children.Clear();
                            Random r = new Random();
                            int numberOfItemrs = r.Next(5, 20);
                            for (int col = 0; col < numberOfItemrs; col++)
                            {
                                Ellipse ellipse = new Ellipse();

                                if ((r.Next(10)) % 10 <= 8)
                                {
                                    ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)(r.Next(120, 255)),
                                        (byte)(r.Next(255)), (byte)(r.Next(120, 255)), (byte)(r.Next(120, 255))));

                                }
                                else
                                {
                                    LinearGradientBrush myBrush = new LinearGradientBrush();
                                    myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
                                    myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
                                    myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));

                                    ellipse.Fill = myBrush;
                                    //check https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/wpf-brushes-overview
                                    //for other brush ideas
                                }
                                ellipse.Width = canvas.ActualWidth / r.Next(2, 8);
                                ellipse.Height = canvas.ActualWidth / r.Next(2, 8);
                                canvas.Children.Add(ellipse);
                                Canvas.SetLeft(ellipse, r.Next(0, (int)(canvas.ActualWidth - ellipse.Width)));
                                Canvas.SetTop(ellipse, r.Next(0, (int)(canvas.ActualHeight - ellipse.Height)));
                            }
                        };
                        break;
                    case "menuLines":
                        mi.Click += (_s, _e) => {

                            canvas.Children.Clear();

                            Line line = new Line();
                            line.Stroke = Brushes.DarkOrange;
                            line.StrokeThickness = 2;
                            line.X1 = 0;
                            line.X2 = canvas.ActualWidth;
                            line.Y1 = canvas.ActualHeight * 0.5;
                            line.Y2 = canvas.ActualHeight * 0.3;

                            canvas.Children.Add(line);

                            Random random = new Random();

                            for (int i = 0; i < 5; i++) // Adjust the loop count as needed
                            {
                                Line lineTmp = new Line();
                                lineTmp.Stroke = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
                                lineTmp.StrokeThickness = 2;
                                lineTmp.X1 = 0;
                                lineTmp.X2 = canvas.ActualWidth;
                                lineTmp.Y1 = canvas.ActualHeight * random.NextDouble();
                                lineTmp.Y2 = canvas.ActualHeight * random.NextDouble();

                                canvas.Children.Add(lineTmp);
                            }


                            Path curvedLine = new Path();
                            curvedLine.Stroke = Brushes.DeepSkyBlue;
                            curvedLine.StrokeThickness = 2;

                            PathGeometry myGeometry = new PathGeometry();
                            PathFigureCollection figureCollection = new PathFigureCollection();
                            PathFigure pathFigure = new PathFigure();
                            pathFigure.StartPoint = new Point(10, 100);
                            PathSegmentCollection psc = new PathSegmentCollection();
                            BezierSegment bs = new BezierSegment();
                            bs.Point1 = new Point(80, 5);
                            bs.Point2 = new Point(230, 190);
                            bs.Point3 = new Point(350, 200);
                            psc.Add(bs);
                            pathFigure.Segments = psc;
                            figureCollection.Add(pathFigure);
                            myGeometry.Figures = figureCollection;
                            curvedLine.Data = myGeometry;
                            canvas.Children.Add(curvedLine);

                        };
                        break;
                    case "menuRandomLines":
                        mi.Click += (_s, _e) => {
                            canvas.Children.Clear();

                            Random random = new Random();

                            int numberOfLines = 10;

                            for (int i = 0; i < numberOfLines; i++)
                            {
                                Line line = new Line();
                                line.Stroke = Brushes.Black;
                                line.StrokeThickness = 2;

                                // Set random coordinates for the line
                                line.X1 = random.Next((int)canvas.ActualWidth);
                                line.Y1 = random.Next((int)canvas.ActualHeight);
                                line.X2 = random.Next((int)canvas.ActualWidth);
                                line.Y2 = random.Next((int)canvas.ActualHeight);

                                canvas.Children.Add(line);
                            }
                            Label label = new Label
                            {
                                Content = "Press [TAB] to regenerate new lines...",
                                FontFamily = new FontFamily("Verdana"),
                                FontWeight = FontWeights.Bold,
                                FontSize = 12,
                                Foreground = Brushes.Black,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                            };
                            canvas.Children.Add(label);

 

                            double xleft = (this.ActualWidth) * 0.5;
                            double xtop = (this.ActualHeight) * 0.5;

                            // Set the position
                            Canvas.SetLeft(label, (xleft - label.ActualWidth * 0.5) - (this.Width * 0.25));
                            Canvas.SetTop(label, (xtop - label.ActualHeight * 0.5));

                            // Canvas.SetTop(label, (canvas.ActualHeight * 0.5));
                            // Canvas.SetLeft(label, (canvas.ActualWidth * 0.5));

                            this.PreviewKeyDown += (_sender, _keyEventArgs) =>
                            {
                                if (_keyEventArgs.Key == Key.Tab)
                                {
                                    // this simulates click on the 'menuRandomLines'
                                    menuRandomLines.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                                }
                            };

                        };
                        break;
                    case "menuText":
                        mi.Click += (_s, _e) => {
                            canvas.Children.Clear();
                            // Create string to draw.
                            String drawString = "Lorem ipsum dolor sit amet";

                            // Create font and brush.
                            Label label = new Label();
                            label.FontFamily = new FontFamily("Arial");
                            label.FontWeight = FontWeights.Bold;
                            label.FontSize = 12;
                            label.Foreground = Brushes.Black;
                            label.Content = drawString;
                            label.LayoutTransform = new RotateTransform(135);

                            canvas.Children.Add(label);
                            Canvas.SetLeft(label, canvas.ActualWidth / 2 - label.ActualWidth / 2);


                            // Create string to draw.
                            string myText = "Vladimir Balabanov";

                            // Create a TextBlock with all parameters assigned.
                            TextBlock textBlock = new TextBlock
                            {
                                FontFamily = new FontFamily("Arial"),
                                FontSize = 18,
                                Foreground = Brushes.MediumVioletRed,
                                FontWeight = FontWeights.Bold

                                };

                            // Split the text into two parts for bolding one part.
                            int boldLength = 9; 
                            textBlock.Inlines.Add(new Run(myText.Substring(0, boldLength)) { FontWeight = FontWeights.Bold });
                            textBlock.Inlines.Add(new Run(myText.Substring(boldLength)));

                            canvas.Children.Add(textBlock);
                        

                            double xleft = (this.ActualWidth) * 0.5;
                            double xtop = (this.ActualHeight) * 0.5;

                            // Set the position
                            Canvas.SetLeft(textBlock, (xleft - textBlock.ActualWidth * 0.5) - (this.Width * 0.25));
                            Canvas.SetTop(textBlock, (xtop - textBlock.ActualHeight * 0.5));

                 

                            isDragging = false;
                            // MouseDown event handler to start dragging.
                            textBlock.MouseDown += (__s, __e) =>
                            {
                                if (__e.LeftButton == MouseButtonState.Pressed)
                                {
                                    isDragging = true;
                                    offset = (Point)(__e.GetPosition(canvas) - new Point(Canvas.GetLeft(textBlock), Canvas.GetTop(textBlock)));
                                }
                            };

                            // MouseMove event handler to move the TextBlock while dragging.
                            textBlock.MouseMove += (__s, __e) =>
                            {
                                if (isDragging)
                                {
                                    Point newPosition = (Point)(__e.GetPosition(canvas) - offset);
                                    Canvas.SetLeft(textBlock, newPosition.X);
                                    Canvas.SetTop(textBlock, newPosition.Y);
                                }
                            };

                            // MouseUp event handler to stop dragging.
                            textBlock.MouseUp += (__s, __e) =>
                            {
                                isDragging = false;
                            };


                        };
                        break;
                    default:
                        break;
                }
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

        // https://gist.github.com/imZack/5481767
        /// <summary>
        /// Form: http://stackoverflow.com/questions/974598/find-all-controls-in-wpf-window-by-type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindVisualChildren2<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren2<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        public static DependencyObject FindInVisualTreeDown(DependencyObject obj, Type type)
        {
            if (obj != null)
            {
                if (obj.GetType() == type)
                {
                    return obj;
                }

                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject childReturn = FindInVisualTreeDown(VisualTreeHelper.GetChild(obj, i), type);
                    if (childReturn != null)
                    {
                        return childReturn;
                    }
                }
            }

            return null;
        }


    }
}
