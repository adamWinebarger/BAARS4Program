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

namespace BAARS_4_Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///    
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            Button2.Content = "Quickscore for \nParent/Teacher Forms";
            
        }

        private void takeTestButton_Click(object sender, RoutedEventArgs e)
        {
            new TesterInfoWindow().Show();
            
        }

        private void quickScoreButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
