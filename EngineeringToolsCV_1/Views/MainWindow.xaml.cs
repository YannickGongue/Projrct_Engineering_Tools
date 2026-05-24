using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EngineeringToolsCV_1.Language;
using EngineeringToolsCV_1.ViewModels;

namespace EngineeringToolsCV_1.Views
{
    /// <summary>
    /// Interaktionslogik für PageLogin.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {         
          InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo != null)
            {
                Culture culture = (Culture)combo.SelectedValue;
               // CultureTB.Text = culture.Name;
                SetCulture(culture.Id);
            }

        }

        private void SetCulture(string cultureName)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        }
     
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
               this.WindowState = WindowState.Maximized;
            }
            else 
            { 
               this.WindowState = WindowState.Normal; 
            }
        }
    }
}
