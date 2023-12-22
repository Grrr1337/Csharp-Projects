using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_INotifyPropertyChanged
{
    /*
     * This ObservableObject class serves as a base class that implements the INotifyPropertyChanged interface.
     * This class is commonly used in the context of data binding in UI frameworks like WPF. 
     * Let me break down its purpose:
     * 
     */

    // Implementing INotifyPropertyChanged for notifying property changes to the UI
    /*
    * The INotifyPropertyChanged interface is used to notify subscribers (such as UI elements) when a property changes. 
    * This is crucial for keeping the UI synchronized with changes in the underlying data.
    */ 
    class ObservableObject : INotifyPropertyChanged
    {
        /*
        * The PropertyChanged event in ObservableObject is an event declared by the INotifyPropertyChanged interface. 
        * It is raised whenever a property changes.
        * This event is essentially a way for an instance of ObservableObject to signal to other parts of the application,
        * typically UI elements, that a property has been modified.
        */
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to raise the PropertyChanged event
        /*
        * The OnPropertyChanged method is a convenient utility method provided by ObservableObject.
        * It simplifies the process of raising the PropertyChanged event. 
        * By using [CallerMemberName], the method automatically retrieves the name of the calling property, 
        * reducing the need to specify the property name explicitly each time.
        */
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            // this is going to utilize reflection in order to update the UI
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}


