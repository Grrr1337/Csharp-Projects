﻿using System;
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

namespace RadioButtonDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // if(true == rbVladimir.IsChecked)
            // {
                // ...
            // }


        }

        private void rbVladimir_Checked(object sender, RoutedEventArgs e)
        {
            lblVladimir.Background = Brushes.Aquamarine;
        }

        private void rbVladimir_Unchecked(object sender, RoutedEventArgs e)
        {
            lblVladimir.Background = Brushes.Transparent;
        }
    }
}
