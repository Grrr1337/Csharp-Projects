using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using WPF_MVVM_Architecture_Pattern2.Models;
using System;
using System.Windows.Input;
using WPF_MVVM_Architecture_Pattern2.Models;


/*
    * ViewModel:

    Acts as an intermediary between the Model and the View.
    Holds the presentation logic, handles user inputs, and prepares data for display in the View.
    Not directly tied to the UI controls but exposes properties that the View binds to.
*/


namespace WPF_MVVM_Architecture_Pattern2.ViewModels
{
    public class PersonViewModel : Base.ViewModelBase
    {
        private Person _person;

        // Example command for demonstration purposes
        public ICommand UpdateCommand { get; }
        public PersonViewModel()
        {
            // Initialize with default values or load from a data source
            _person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 25
            };

            // Example command for demonstration purposes
            UpdateCommand = new RelayCommand(ExecuteUpdateCommand, CanExecuteUpdateCommand);
        }

        // this constructor is prefered, in order to pass some default data to this ViewModel -
        public PersonViewModel(Person person)
        {
            // Initialize with default values or load from a data source
            _person = person;
       
            // Example command for demonstration purposes
            UpdateCommand = new RelayCommand(ExecuteUpdateCommand, CanExecuteUpdateCommand);
        }

        public string FirstName
        {
            get { return _person.FirstName; }
            set
            {
                if (_person.FirstName != value)
                {
                    _person.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set
            {
                if (_person.LastName != value)
                {
                    _person.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public int Age
        {
            get { return _person.Age; }
            set
            {
                if (_person.Age != value)
                {
                    _person.Age = value;
                    OnPropertyChanged(nameof(Age));
                }
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
