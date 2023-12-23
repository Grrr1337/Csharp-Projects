using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Architecture_Pattern3.Models;

using System.Windows.Input;
using System.Windows;

/*
    * ViewModel:

    Acts as an intermediary between the Model and the View.
    Holds the presentation logic, handles user inputs, and prepares data for display in the View.
    Not directly tied to the UI controls but exposes properties that the View binds to.
*/

namespace WPF_MVVM_Architecture_Pattern3.ViewModels
{
    // AnimalViewModel.cs
    public class AnimalViewModel : Base.ViewModelBase // Assume a base class for ViewModelBase
    {
        private Animal _animal;
        // New command to close the dialog with result OK
        public ICommand CloseDialogCommand { get; }

        public AnimalViewModel()
        {
            // Initialize with default values or load from a data source
            _animal = new Animal
            {
                Species = "Lion",
                Sound = "Roar"
            };

            // Initialize the CloseDialogCommand
            CloseDialogCommand = new RelayCommand(ExecuteCloseDialogCommand, CanExecuteCloseDialogCommand);

        }

        // this constructor is prefered, in order to pass some default data to this ViewModel -
        public AnimalViewModel(Animal animal)
        {
            _animal = animal;

            // Initialize the CloseDialogCommand
            CloseDialogCommand = new RelayCommand(ExecuteCloseDialogCommand, CanExecuteCloseDialogCommand);
        }

        // Properties to bind to the View
        public string Species
        {
            get { return _animal.Species; }
            set
            {
                if (_animal.Species != value)
                {
                    _animal.Species = value;
                    OnPropertyChanged(nameof(Species));
                }
            }
        }

        public string Sound
        {
            get { return _animal.Sound; }
            set
            {
                if (_animal.Sound != value)
                {
                    _animal.Sound = value;
                    OnPropertyChanged(nameof(Sound));
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
