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
using System.Windows.Shapes;
using System.IO;

namespace BAARS_4_Tester
{
    /// <summary>
    /// Interaction logic for TesterInfoWindow.xaml
    /// </summary>
    public partial class TesterInfoWindow : Window
    {
        private int age;
        private string firstName, middleName, lastName, gender;

        private string path = "Tester_Profiles";

        

        public TesterInfoWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if(!checkRequiredFields())
            {
                return;
            }

            if (checkRequiredFields())
            {
                createDirectory4Tester();
                createTesterInfoTextFile();

                TestType testType;

                if (age > 18)
                {
                    testType = TestType.adult;
                } else if (age <= 18)
                {
                    testType = TestType.youth;
                } else
                {
                    return; //~should be unreachable
                }

                new TestWindow(testType, firstName, lastName, middleName, gender, path, age).Show();
                Close();
            }
        }

        private void ageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!ageIsValid())
            {
                MessageBox.Show("Error! Invalid Input Detected", "Response");
                ageTextBox.Text = null;
            }
        }

        private void maleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            femaleRadioButtton.IsChecked = false;
        }

        private void femaleRadioButtton_Checked(object sender, RoutedEventArgs e)
        {
            maleRadioButton.IsChecked = false;
        }

        private bool checkRequiredFields()
        {
            if (firstNameTextBox.Text.Equals("") || lastNameTextbox.Text.Equals(""))
            {
                return false;
            }

            if (!int.TryParse(ageTextBox.Text, out age))
            {
                return false;
            }

            if ((bool)!maleRadioButton.IsChecked && (bool)!femaleRadioButtton.IsChecked)
            {
                return false;
            }

            return true;
        }

        private bool ageIsValid()
        {
            if (!int.TryParse(ageTextBox.Text, out age) && ageTextBox.Text != "" && ageTextBox.Text != null)
            {
                return false;
            }

            return true;
        }

        private void createDirectory4Tester()
        {
            firstName = firstNameTextBox.Text;
            middleName = middleNameTextBox.Text;
            lastName = lastNameTextbox.Text;

            if (maleRadioButton.IsChecked.Equals(true))
            {
                gender = "male";
            } else if (femaleRadioButtton.IsChecked.Equals(true))
            {
                gender = "female";
            } else
            {
                gender = "???"; //should be unreachable code
            }

            string directoryPath = path + "\\" + lastName + ", " + firstName;

            if (middleName != "" && middleName != null)
            {
                directoryPath += middleName[0] + ".";
            }

            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                path = directoryPath;
                return;
            } else
            {
                int duplicateCount = 2;

                while (Directory.Exists(directoryPath + " (" + duplicateCount.ToString() + ")"))
                {
                    duplicateCount++;
                }

                directoryPath += " (" + duplicateCount.ToString() + ")";
                Directory.CreateDirectory(directoryPath);
                path = directoryPath;
            }
        }

        private void createTesterInfoTextFile()
        {
            string testerInfoFilePath = path + "\\TesterInfo.txt";

            string[] info = {"Last Name: ", lastName, "", "First Name: ", firstName, "", "Middle Name: ",
                middleName, "", "Age: ", age.ToString(), "", "Gender: ", gender, "", "Path: ", path, "" };

            if (!File.Exists(testerInfoFilePath))
            {
                using (StreamWriter writer = File.CreateText(testerInfoFilePath))
                {
                    for (int i = 0; i < info.Length; i += 3)
                    {
                        writer.WriteLine("{0}{1}", info[i], info[i + 1]);
                        writer.WriteLine(info[i + 2]);
                    }
                }
            }
        }
    }
}