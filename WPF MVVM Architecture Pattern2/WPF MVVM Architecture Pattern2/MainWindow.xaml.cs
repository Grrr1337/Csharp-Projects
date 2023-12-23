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

// Import all of them -
// I need 'Models', so I could provide default parameters to the constructors of the 'ViewModels'
using WPF_MVVM_Architecture_Pattern2.Models;
// I need 'ViewModels' so I could create new viewModel instances and assign them to a View instance, like so:
/*
// Create an instance of PersonView and its ViewModel
PersonView _personView = new PersonView();
PersonViewModel _personViewModel = new PersonViewModel();

// Set the DataContext of the PersonView to its ViewModel
_personView.DataContext = _personViewModel;
 */
using WPF_MVVM_Architecture_Pattern2.ViewModels;
// I almost always need 'Views', either to do this:
/* Embed it to an existing control, located in the mainWindow
animalView = new AnimalView();
animalDataFrame.Content = animalView;
 */
// or to do this (insantiate it in a separate window) :
/*
// Create a new window
Window _animalWindow = new Window
{
    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
    Title = "Animal Window",
    Content = _animalView,
    // SizeToContent = SizeToContent.WidthAndHeight,
    ResizeMode = ResizeMode.NoResize,
    Width = this.Width,
    Height = this.Height,
};
 */
using WPF_MVVM_Architecture_Pattern2.Views;

namespace WPF_MVVM_Architecture_Pattern2
{
    /// MainWindow.xaml.cs

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<FrameworkElement> views;

        AnimalView animalView { get; set; }
        CarView carView { get; set; }
        PersonView personView { get; set; }

        // bez da imam definirani ViewModel-i, nqma da imam dostup do code-behind-a na samia View
        AnimalViewModel animalViewModel { get; set; }
        CarViewModel carViewModel { get; set; }
        PersonViewModel personViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Title = "MVVM Exploration";
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Focusable = true;
            this.Focus();
            this.Loaded += MainWindow_Loaded;

        }// public MainWindow()

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
         
            
            // Nai-nai purvona4alnata versiq, kudeto napravih amatiorska greshka (da ne go vurja s ViewModel-a mu) :
            animalView = new AnimalView();
            animalDataFrame.Content = animalView;
            // animalViewModel = new AnimalViewModel(new Animal { Type = "Cat", Species = "Mammal", Sound = "meow" }); // <- ETO tova, NE GO NAPRAVIH v na4aloto !
            // i suotvetno ne go izpolzvah pri 'btnAnimal.Click' event handler-a
            // animalView.DataContext = animalViewModel; // <- ETO tova, NE GO NAPRAVIH v na4aloto !

            animalView.btnOk.Visibility = Visibility.Collapsed; // <-- hide that button
            animalView.lblMessage.Visibility = Visibility.Collapsed;

            // Tuka vruzvam View-a s negovia ViewModel, i posle moga da go dostupq prez code-behind:
            carView = new CarView();
            carViewModel = new CarViewModel(new Car { Model = "", Year = 0, Color = "" });
            carView.DataContext = carViewModel;
            carDataFrame.Content = carView;
            carView.btnOk.Visibility = Visibility.Collapsed; // <-- hide that button
            carView.lblMessage.Visibility = Visibility.Collapsed;

            // Tuka vruzvam View-a s negovia ViewModel, i posle moga da go dostupq prez code-behind:
            personView = new PersonView();
            personViewModel = new PersonViewModel(new Person { FirstName="Vladimir", LastName="Balabanov", Age=1337});
            personView.DataContext = personViewModel;
            personDataFrame.Content = personView;
            personView.lblMessage.Visibility = Visibility.Collapsed;

            views = new List<FrameworkElement> { animalView, carView, personView };

            personView.tbFirstName.MouseEnter += (_s, _e) =>
            {
                if (_s is TextBox textBox)
                {
                    textBox.Text = "Vladimir";
                    // Predi praveh tova, poneje ne bqh instanciral ViewModel, koito da e vurzan kum CarView class-a
                    // carView.tbModel.Text = "Lamborghini";

                    // Sega, poneje sum vurzal View-a s negovia ViewModel, moga da napravq tova:
                    carViewModel.Model = "Lambo";
                    // po tozi na4in ne sa mi neobhodimi x:Name na XAML kontrolite vuv view-a!
                    
                    // I can trigger an event in the View class:
                    // personView.btnUpdate.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    // but I cannot access directly the property which is in the `ViewModel`

                }
            };

            personView.tbFirstName.MouseLeave += (_s, _e) =>
            {
                if (_s is TextBox textBox)
                {
                    textBox.Text = "";
                    carView.tbModel.Text = "";
                }
            };


            #region Instantiation of ViewModels upon Button.Click events
            /// Region:
            /// Button click Event handlers, where new ViewModels are instantiated
            /// Principno ako razsujdavame na nikoi nqma da mu se nalaga da pravi po 2 instancii ot 1 sushti klas, zashtoto moje prosto eto tova da se naprawi:
            /* Samo deto ne raboti pravilno, ta moje bi gresha
            btnAnimal.Click += (_s, _e) =>
            {
            // Create a new window
                Window _animalWindow = new Window
                {
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                    Title = "Animal Window",
                    Content = animalView,
                    // SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize,
                    Width = this.Width * 0.9,
                    Height = this.Height * 0.9,
                };

                // Show the window
                bool? result = _animalWindow.ShowDialog();

                if (result.HasValue && result.Value)
                {
                    tbAnimalSpecies.Text = _animalViewModel.Species;
                    tbAnimalSound.Text = _animalViewModel.Sound;
                }
            };
             */

            btnAnimal.Click += (_s, _e) =>
            {
                this.Opacity = 0.5;

                // Create an instance of AnimalView and its ViewModel
                AnimalView _animalView = new AnimalView();
                // AnimalViewModel _animalViewModel = new AnimalViewModel(new Animal { Species = "Cat", Sound = "" });

                // use the default values from the mainWindow
                AnimalViewModel _animalViewModel = new AnimalViewModel(new Animal { Species = tbAnimalSpecies.Text, Sound = tbAnimalSound.Text });

                // Set the DataContext of the AnimalView to its ViewModel
                _animalView.DataContext = _animalViewModel;

                // Create a new window
                Window _animalWindow = new Window
                {
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                    Title = "Animal Window",
                    Content = _animalView,
                    // SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize,
                    Width = this.Width * 0.9,
                    Height = this.Height * 0.9,
                };

                // Show the window
                bool? result = _animalWindow.ShowDialog();

                if (result.HasValue && result.Value)
                {
                    // OK button or positive result was clicked
                    // Do something based on a positive result
                    // MessageBox.Show(_animalViewModel.Species.ToString()); //<-- here I can access the property from the code behind
                    tbAnimalSpecies.Text = _animalViewModel.Species;
                    tbAnimalSound.Text = _animalViewModel.Sound;
                }
                else
                {
                    // Cancel button or negative result was clicked, or the window was closed
                    // Do something based on a negative result or cancellation
                }

                this.Opacity = 1;
            };// btnAnimal.Click
            

            btnCar.Click += (_s, _e) =>
            {
                this.Opacity = 0.5;

                // Create an instance of CarView and its ViewModel
                CarView _carView = new CarView();
                // CarViewModel _carViewModel = new CarViewModel();

                // https://stackoverflow.com/questions/10693231/elegant-tryparse
                int year = int.TryParse(tbCarYear.Text, out year) ? year : 0;
                // CarViewModel _carViewModel = new CarViewModel(new Car { Model = tbCarModel.Text, Year = year, Color = tbCarColor.Text });

                // No moga da go vurja i s drugiq View, koito e embed-nat kum MainWindow-a, eto taka:
                // this is the incorrect way to do it:
                // CarViewModel _carViewModel = carViewModel;

                // this is the right way to do it:
                /*
                CarViewModel _carViewModel = new CarViewModel(new Car
                {
                    Model = carViewModel.Model,
                    Year = carViewModel.Year,
                    Color = carViewModel.Color
                });
                */
                // moje i taka, no trqbva da imam 'Copy Constructor' v ViewModel.cs koda:
                CarViewModel _carViewModel = new CarViewModel(carViewModel);

                // Set the DataContext of the CarView to its ViewModel
                _carView.DataContext = _carViewModel;

                // Create a new window
                Window _carWindow = new Window
                {
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                    Title = "Car Window",
                    Content = _carView,
                    // SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize,
                    Width = this.Width * 0.9,
                    Height = this.Height * 0.9,

                };

                /*
                // Show the window
                _carWindow.ShowDialog(); // Regardless of the result
                // MessageBox.Show(_carViewModel.Model.ToString());
                tbCarModel.Text = _carViewModel.Model;
                tbCarYear.Text = _carViewModel.Year.ToString();
                tbCarColor.Text = _carViewModel.Color;
                */

                // Show the window
                bool? result = _carWindow.ShowDialog();

                if (result.HasValue && result.Value)
                {
                    // OK button or positive result was clicked
                    // Do something based on a positive result
                    // MessageBox.Show(_animalViewModel.Species.ToString()); //<-- here I can access the property from the code behind

                    // this doesn't work
                    // carViewModel = new CarViewModel(_carViewModel); // <- usually I would need something like this
                    // TODO - to figure out a short way how to assign these:
                    // carViewModel.Model = _carViewModel.Model;
                    // carViewModel.Year = _carViewModel.Year;
                    // carViewModel.Color = _carViewModel.Color;
                    carViewModel.CopyPropertiesFrom(_carViewModel);

                    tbCarModel.Text = _carViewModel.Model;
                    tbCarYear.Text = _carViewModel.Year.ToString();
                    tbCarColor.Text = _carViewModel.Color;
                    // MessageBox.Show("Ok");
                }
                else
                {
                    // MessageBox.Show("Cancel");
                    // Cancel button or negative result was clicked, or the window was closed
                    // Do something based on a negative result or cancellation
                }

                this.Opacity = 1;

            };// btnCar.Click

            btnPerson.Click += (_s, _e) =>
            {
                this.Opacity = 0.5;

                // Create an instance of PersonView and its ViewModel
                PersonView _personView = new PersonView();
                // PersonViewModel _personViewModel = new PersonViewModel();

                int age = int.TryParse(tbPersonAge.Text, out age) ? age : 0;
                // Tova go vurzva po default s result box-a:
                // PersonViewModel _personViewModel = new PersonViewModel(new Person { FirstName = tbPersonFirstName.Text, LastName = tbPersonLastName.Text, Age = age });

                // No moga da go vurja i s drugiq View, koito e embed-nat kum MainWindow-a, eto taka:
                PersonViewModel _personViewModel = personViewModel;


                // Set the DataContext of the PersonView to its ViewModel
                _personView.DataContext = _personViewModel;

                // Create a new window
                Window _personWindow = new Window
                {
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                    Title = "Person Window",
                    Content = _personView,
                    // SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize,
                    Width = this.Width * 0.9,
                    Height = this.Height * 0.9,
                };

                // Show the window
                _personWindow.ShowDialog();
                // MessageBox.Show(_personViewModel.FirstName);
                tbPersonFirstName.Text = _personViewModel.FirstName;
                tbPersonLastName.Text = _personViewModel.LastName;
                tbPersonAge.Text = _personViewModel.Age.ToString();

                // Moga i da napravq tova ako iskam, da zadam na embednatia prozorec, stoinostite ot instanciata:
                personViewModel = _personViewModel;

                this.Opacity = 1;
            };// btnPerson.Click

            #endregion Instantiation of ViewModels upon Button.Click events

        }// private void MainWindow_Loaded
    }// public partial class MainWindow : Window
}// namespace WPF_MVVM_Architecture_Pattern2

