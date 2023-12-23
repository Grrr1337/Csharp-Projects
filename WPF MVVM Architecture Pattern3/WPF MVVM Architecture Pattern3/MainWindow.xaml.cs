using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

using WPF_MVVM_Architecture_Pattern3.Models;
using WPF_MVVM_Architecture_Pattern3.ViewModels;
using WPF_MVVM_Architecture_Pattern3.Views;
using WPF_MVVM_Architecture_Pattern3.ViewModels.Base;
using System.Reflection;
using System.Diagnostics;

namespace WPF_MVVM_Architecture_Pattern3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<FrameworkElement> views;
        private int currentViewIndex = 0;

        private AnimalView animalView;
        private CarView carView;
        private PersonView personView;

        private AnimalViewModel animalViewModel;
        private CarViewModel carViewModel;
        private PersonViewModel personViewModel;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWindowProperties();
            Loaded += MainWindow_Loaded;
        }

        private void InitializeWindowProperties()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "MVVM Exploration";
            ResizeMode = ResizeMode.NoResize;
            Focusable = true;
            Focus();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeViewsAndViewModels();
            views = new List<FrameworkElement> { animalView, personView, carView };
            mainFrame.Content = views[currentViewIndex];
            CreateMenu();
            AttachButtonEvents();
        }

        private void InitializeViewsAndViewModels()
        {
            animalView = new AnimalView();
            animalViewModel = new AnimalViewModel();
            animalView.DataContext = animalViewModel;

            carView = new CarView();
            carViewModel = new CarViewModel(new Car { Model = "", Year = 0, Color = "" });
            carView.DataContext = carViewModel;

            personView = new PersonView();
            personViewModel = new PersonViewModel();
            personView.DataContext = personViewModel;
        }

        private void AttachButtonEvents()
        {
            btnAlertProps.Click += (_, __) => ShowActiveViewProperties();
            btnSwitch.Click += (_, __) => SwitchToNextView();
            btnShowAsInstance.Click += (_, __) => ShowViewAsInstance();
        }

        private void ShowActiveViewProperties()
        {
            FrameworkElement activeView = mainFrame.Content as FrameworkElement;

            if (activeView != null)
            {
                object viewModel = activeView.DataContext;

                if (viewModel != null)
                {
                    var properties = viewModel.GetType().GetProperties();
                    StringBuilder message = new StringBuilder();

                    foreach (var property in properties)
                    {
                        if (property.Name.StartsWith("Can") || property.Name.StartsWith("Is"))
                            continue;

                        object value = property.GetValue(viewModel);

                        if (value == null)
                            value = "null";

                        message.AppendLine($"{property.Name}: {value}");
                    }

                    MessageBox.Show(message.ToString(), "Active View Properties");
                }
            }
        }

        private void SwitchToNextView()
        {
            currentViewIndex = (currentViewIndex + 1) % views.Count;
            mainFrame.Content = views[currentViewIndex];
        }

        // Still have a work to do in here
        private void ShowViewAsInstance()
        {
            this.Opacity = 0.1;
            FrameworkElement clonedView = CloneFrameworkElement(views[currentViewIndex]);
            ViewModelBase clonedViewModel = CreateViewModelForView<ViewModelBase>(views[currentViewIndex]);

            Window window = new Window
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Instance Window",
                Content = clonedView,
                ResizeMode = ResizeMode.NoResize,
                Width = this.Width * 0.9,
                Height = this.Height * 0.9,
            };

            bool? result = window.ShowDialog();
            Type baseViewModelType = typeof(ViewModelBase);
            Type viewModelType = GetViewModelTypeForViewType(views[currentViewIndex].GetType());

            HandleViewModelTypeMismatch(baseViewModelType, viewModelType, clonedViewModel);

            if (result.HasValue && result.Value)
            {
                MessageBox.Show("OK");
            }
            else
            {
                // MessageBox.Show("Cancel");
            }

            this.Opacity = 1;
        }

        private FrameworkElement CloneFrameworkElement(FrameworkElement original)
        {
            return (FrameworkElement)Activator.CreateInstance(original.GetType());
        }

        private void HandleViewModelTypeMismatch(Type baseViewModelType, Type viewModelType, ViewModelBase clonedViewModel)
        {
            if (baseViewModelType.IsAssignableFrom(viewModelType))
            {
                ViewModelBase originalViewModel = views[currentViewIndex].DataContext as ViewModelBase;

                if (originalViewModel != null)
                {
                    originalViewModel.CopyPropertiesFrom(clonedViewModel);
                }
            }
            else
            {
                // Debug.WriteLine($"Type mismatch between ViewModels: BaseViewModelType = {baseViewModelType.FullName}, ActualViewModelType = {viewModelType.FullName}");
                // MessageBox.Show("Type mismatch between ViewModels");
            }
        }

        private Type GetViewModelTypeForViewType(Type viewType)
        {
            string viewTypeName = viewType.Name;
            string viewModelTypeName = $"{viewTypeName}Model";
            Type viewModelType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(type => type.FullName == viewModelTypeName);

            if (viewModelType == null)
            {
                Debug.WriteLine($"Unable to find the ViewModel type for {viewTypeName}");
            }

            return viewModelType;
        }

        private T CreateViewModelForView<T>(FrameworkElement view) where T : ViewModelBase
        {
            T viewModel = view.DataContext as T;

            if (viewModel == null)
            {
                MessageBox.Show("ViewModel is null or not of the expected type");
                return null;
            }

            return viewModel;
        }

        private void CreateMenu()
        {
            Menu menu = new Menu();
            menu.FontSize = 16;

            MenuItem menuItem = new MenuItem();
            menuItem.Header = "_Choose a window to set";

            MenuItem[] subMenuItems = new MenuItem[]
            {
                CreateMenuItem("Animal", animalView),
                CreateMenuItem("Person", personView),
                CreateMenuItem("Car", carView),
            };

            foreach (MenuItem mi in subMenuItems)
            {
                menu.Items.Add(mi);
            }

            DockPanel.SetDock(menu, Dock.Top);
            mainDockPanel.Children.Add(menu);
        }

        private MenuItem CreateMenuItem(string header, FrameworkElement view)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Header = header;

            menuItem.Click += (_, __) =>
            {
                mainFrame.Content = view;
            };

            return menuItem;
        }
    }
}
