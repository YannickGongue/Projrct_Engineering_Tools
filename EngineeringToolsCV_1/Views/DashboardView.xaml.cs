using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EngineeringToolsCV_1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private DashboardViewModel VmDashboard;
        private InformationView pageInformation;
        private BerufView PageBeruf;
        public List<Page> ListOfPages;


        public DashboardView()
        {
            //this.VmDashboard = new DashboardViewModel();
            ListOfPages = new List<Page>();
            //this.pageInformation = new InformationView();
            //this.PageBeruf = new BerufView();

            InitializeComponent();

            //ListOfPages.Add(this.pageInformation);
            //ListOfPages.Add(this.PageBeruf);

          
        }


        private void InfoToggleButton_Click(object sender, RoutedEventArgs e)
        {
           
        }     

        private void BerufToggleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AusbildungToggleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ProjektToggleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void QualifikationToggleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TätigkeitToggleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MediaToggleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ConfigToggleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HobbyToggleButton_Click (object sender, RoutedEventArgs e)
        {
            
        }      
    }
}
