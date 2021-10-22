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
using System.IO;
using System.Diagnostics;

namespace BAARS_4_Tester
{
    /* 
     * Main Window for the BAARS 4 Tester
     * */

    public partial class MainWindow : Window
    {

        // Runs on start of window
        public MainWindow()
        {
            InitializeComponent();
            Button2.Content = "Quickscore for \nParent/Teacher Forms";
            LoadDataIntoTable();
        }

        // Button to get user to take test, opens user information input window
        private void TakeTestButton_Click(object sender, RoutedEventArgs e)
        {
            new TesterInfoWindow().Show();
        }

        // Quickly calculate the score
        private void QuickScoreButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // Loads the names into the main window table
        private void LoadDataIntoTable()
        {
            Debug.WriteLine("here");
            string[] files1 = Directory.GetDirectories("Tester_Profiles\\");

            //LinkedList <Tester> = new LinkedList<Tester>();

            int numOfPeople = files1.Length;
            //var names = new List<String>();

            List<Tester> names = new List<Tester>();
  
            for (int i = 0; i < numOfPeople; i++)
            {
                // string[] directoryName = files1[i].Split(' ');
                names.Add(new Tester(files1[i]));
            }

            Table.IsReadOnly = true;
            Table.ItemsSource = names;

        }
    }
}
