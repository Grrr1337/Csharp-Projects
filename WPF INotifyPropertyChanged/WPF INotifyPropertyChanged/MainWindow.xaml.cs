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

namespace WPF_INotifyPropertyChanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Title = "WPF INotifyPropertyChanged tests";
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Focusable = true;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            Explicit Update:
                To update the source property (Name), you need to explicitly trigger the update. 
                This is typically done programmatically in your code-behind.
            */
            // So I have decided to explicitly update upon 'MouseDoubleClick' event
            tbExplict.MouseDoubleClick += (_s, _e) =>
            {
                // Assuming DataContext is an instance of PersonModel
                ((PersonModel)this.DataContext).Name = tbExplict.Text;
                // Explicitly trigger the update
                BindingExpression bindingExpression = tbExplict.GetBindingExpression(TextBox.TextProperty);
                // So, with UpdateSourceTrigger=Explicit, the source property (Name in this case) is only updated
                // when you call UpdateSource() explicitly on the binding expression.
                bindingExpression?.UpdateSource();

            };
        }
    }
}
