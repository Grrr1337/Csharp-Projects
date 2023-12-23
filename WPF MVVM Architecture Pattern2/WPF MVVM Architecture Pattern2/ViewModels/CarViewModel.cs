using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using WPF_MVVM_Architecture_Pattern2.Models;


using System.Windows.Input;
using System.Windows;

/*
    * ViewModel:

    Acts as an intermediary between the Model and the View.
    Holds the presentation logic, handles user inputs, and prepares data for display in the View.
    Not directly tied to the UI controls but exposes properties that the View binds to.
*/


namespace WPF_MVVM_Architecture_Pattern2.ViewModels
{
    public class CarViewModel : Base.ViewModelBase
    {
        private Car _car;
        // Example command for demonstration purposes
        public ICommand UpdateCommand { get; }

        // New command to close the dialog with result OK
        public ICommand CloseDialogCommand { get; }

        public CarViewModel()
        {
            // Initialize with default values or load from a data source
            _car = new Car
            {
                Color = "Red",
                Model = "Sedan",
                Year = 2023
            };

            // Example command for demonstration purposes
            // UpdateCommand = new RelayCommand(ExecuteUpdateCommand, CanExecuteUpdateCommand);

            // Initialize the CloseDialogCommand
            CloseDialogCommand = new RelayCommand(ExecuteCloseDialogCommand, CanExecuteCloseDialogCommand);

        }


        // this constructor is prefered, in order to pass some default data to this ViewModel -
        public CarViewModel(Car car)
        {
            // Initialize with default values or load from a data source
            _car = car;
       

            // Example command for demonstration purposes
            // UpdateCommand = new RelayCommand(ExecuteUpdateCommand, CanExecuteUpdateCommand);

            // Initialize the CloseDialogCommand
            CloseDialogCommand = new RelayCommand(ExecuteCloseDialogCommand, CanExecuteCloseDialogCommand);
        }

        // Copy constructor
        public CarViewModel(CarViewModel other)
        {
            _car = new Car
            {
                Color = other.Color,
                Model = other.Model,
                Year = other.Year
            };

            // Copy other properties or perform additional initialization if needed

            // Example command for demonstration purposes
            CloseDialogCommand = new RelayCommand(ExecuteCloseDialogCommand, CanExecuteCloseDialogCommand);
        }

        public string Color
        {
            get { return _car.Color; }
            set
            {
                if (_car.Color != value)
                {
                    _car.Color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        public string Model
        {
            get { return _car.Model; }
            set
            {
                if (_car.Model != value)
                {
                    _car.Model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        public int Year
        {
            get { return _car.Year; }
            set
            {
                if (_car.Year != value)
                {
                    _car.Year = value;
                    OnPropertyChanged(nameof(Year));
                }
            }
        }

    

        private bool CanExecuteCloseDialogCommand(object parameter)
        {
            // Add your logic for when the command can be executed
            return true;
        }

        private void ExecuteCloseDialogCommand(object parameter)
        {
            // Get the associated window from the command parameter
            if (parameter is Window window)
            {
                // Set the DialogResult to true and close the window
                CloseWindowWithResult(window, true);
            }
        }

        private void CloseWindowWithResult(Window window, bool result)
        {
            // Check if the window is not null and set its DialogResult
            if (window != null)
            {
                window.DialogResult = result;
                window.Close();
            }
        }


        private bool CanExecuteUpdateCommand(object parameter)
        {
            // Add your logic for when the command can be executed
            return true;
        }

        private void ExecuteUpdateCommand(object parameter)
        {
            // Add your logic for when the command is executed
        }

        // ICommand implementation without RelayCommand
        private class RelayCommand : ICommand
        {
            private readonly Action<object> _execute;
            private readonly Func<object, bool> _canExecute;

            public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

            public void Execute(object parameter) => _execute(parameter);
        }
    }
}
