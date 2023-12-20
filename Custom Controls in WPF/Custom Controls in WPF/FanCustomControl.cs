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

namespace Custom_Controls_in_WPF
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Custom_Controls_in_WPF"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Custom_Controls_in_WPF;assembly=Custom_Controls_in_WPF"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:FanCustomControl/>
    ///
    /// </summary>
    /// 

    // When we are creating a 'Custom Control' it is directly inheriting from the 'Control' class
    public class FanCustomControl : Control // <- we can see that it directly inherits from the 'Control' class
    {
        /*
        Inside of this class we define the core functionality of the custom control
        so we can add things like properties, methods, events and so on.. (everything related to the core functionality)
        When it comes to the UI, it is defined by using a control template, and it can be set by setting a control template property.
        */
        /* Inside of our project in: Themes->Generic
         the WPF looks for our control
         */


        public bool FanOn
        {
            get { return (bool)GetValue(FanOnProperty);  }
            set { SetValue(FanOnProperty, value);  }
        }
 
        public static readonly DependencyProperty FanOnProperty = DependencyProperty.Register("FanOn", typeof(bool), typeof(FanCustomControl), new PropertyMetadata(false));


        static FanCustomControl()
        {
            // Template = new ControlTemplate(); // <-- with this we can define the UI

            DefaultStyleKeyProperty.OverrideMetadata(typeof(FanCustomControl), new FrameworkPropertyMetadata(typeof(FanCustomControl)));
        }
    }
}
