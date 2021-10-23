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

        List<Tester> names = new List<Tester>();
        List<Tester> filteredNames = new List<Tester>();

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

            int numOfPeople = files1.Length;
  
            for (int i = 0; i < numOfPeople; i++)
            {
                names.Add(new Tester(files1[i]));
                filteredNames.Add(new Tester(files1[i]));
            }

            Table.IsReadOnly = true;
            Table.ItemsSource = names;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchTable();
        }
        
        private void SearchTable()
        {
            filteredNames.Clear();

            if (SearchBox.Text.Equals(""))
            {
                filteredNames.AddRange(names);
            }
            else
            {
                if (firstNameCheckBox.IsChecked.GetValueOrDefault())
                {
                    foreach (Tester t in names)
                    {
                        if (t.firstName.Contains(SearchBox.Text) && !filteredNames.Contains(t))
                        {
                            filteredNames.Add(t);
                        }
                    }
                }
                if (middleNameCheckBox.IsChecked.GetValueOrDefault())
                {
                    foreach (Tester t in names)
                    {
                        if (t.middleName.Contains(SearchBox.Text) && !filteredNames.Contains(t))
                        {
                            filteredNames.Add(t);
                        }
                    }
                }
                if (lastNameCheckBox.IsChecked.GetValueOrDefault())
                {
                    foreach (Tester t in names)
                    {
                        if (t.lastName.Contains(SearchBox.Text) && !filteredNames.Contains(t))
                        {
                            filteredNames.Add(t);
                        }
                    }
                }
            }

            Table.ItemsSource = filteredNames.ToList();
        }

        private void RowClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void FirstName_Checked(object sender, RoutedEventArgs e)
        {
            firstNameCheckBox.IsChecked = true;
            SearchTable();
        }

        private void MiddleName_Checked(object sender, RoutedEventArgs e)
        {
            middleNameCheckBox.IsChecked = true;
            SearchTable();
        }

        private void LastName_Checked(object sender, RoutedEventArgs e)
        {
            lastNameCheckBox.IsChecked = true; 
            SearchTable();
        }

        private void Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataGridRow row = sender as DataGridRow;

                MessageBox.Show(filteredNames[row.GetIndex()].path.ToString());
            }
            catch
            {

            }

    
        }
    }
}
