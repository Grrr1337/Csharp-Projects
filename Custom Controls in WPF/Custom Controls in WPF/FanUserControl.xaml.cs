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
    /// Interaction logic for FanUserControl.xaml
    /// </summary>
    /// 

    // Here we can see that it inherits from the UserControl class, while the UserControl class inheits from the ContentControl class
    // and the ContentControl class inherits from the Control class
    // which means that when we are creating a 'Custom Control' it is directly inheriting from the 'Control' class
    // while when we are creating an UserControl class it is like so: UserControl->ContentControl->Control
    public partial class FanUserControl : UserControl
    {
        public FanUserControl()
        {
            InitializeComponent();
        }
    }
}
