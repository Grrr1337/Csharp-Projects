using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_INotifyPropertyChanged
{
    /*
     * A quick recap:
     * You don't need to implement the 'INotifyPropertyChanged'
     * if you intend to update the UI from the UI
     * and the binding object is a plain old clr object
     * 
     * But if you do plan on changing the value from the code behind
     * then it is highly recommended to implement the 'INotifyPropertyChanged'
     */

    // Inheriting from ObservableObject to utilize INotifyPropertyChanged
    class PersonModel : ObservableObject
    {
        // Property with OnPropertyChanged call to notify UI about changes
        // type in: propfull [TAB] [TAB]
        private string _name;

        public string Name
        {
            get { return _name; }
            /*
             * This setter property (1st version) is a standard property without any notification mechanism. 
             * When you set the Name property in your code, there is no automatic notification
             * to inform other parts of your application (such as UI elements bound to this property) 
             * that the value has changed. 
             * This can lead to situations where the UI is not updated when the underlying data changes.
             */
            // set { _name = value; } // <-- 1st version
            /*
             * This setter property (2nd version) with OnPropertyChanged is designed to provide a mechanism 
             * for notifying other parts of your application about changes to the property value,
             * which is particularly important when working with data binding in WPF or other UI frameworks.
             */
            set { _name = value;  OnPropertyChanged("Name"); } // <-- 2nd version (it behaves like a listener)
        }// public string Name

        // Constructor for testing purposes (updating Name property in a separate thread)
        // ctor [TAB] [TAB]
        public PersonModel()
        {
            /*
            Task.Run(() =>
            {
                while(true)
                {
                    // Here we just assign some value to the 'Name' property and observe the effect of the 'OnPropertyChanged'
                    Random r = new Random();
                    Name = r.Next(1, 1000).ToString(); // <-- 

                    // note: run in debug mode and check the 'output' tab, while using the UI
                    Debug.WriteLine($"Name: {Name}");
                    // Delaying the thread (not recommended in a real application)
                    Thread.Sleep(500);
                }
            });
            */
        }
    }
}
