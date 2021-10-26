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
using System.Windows.Shapes;
using System.IO;

namespace BAARS_4_Tester
{

    /// <summary>
    /// Interaction logic for TesterAnswers.xaml
    /// </summary>
    public partial class TesterAnswers : Window
    {
        public struct AnswersTable
        {
            public string Quesetions { get; set; }
            public string Answers { get; set; }
        }

        Tester t;
        private AnswersTable[] tableData = new AnswersTable[25];

        public TesterAnswers(Tester t)
        {
            this.t = t;
            InitializeComponent();
            getAnswers();
            display.Text = t.firstName+ " " + t.middleName + " " + t.lastName;
        }

        private void getAnswers()
        {
            if (File.Exists(t.path + "\\Answers.txt"))
            {
                //MessageBox.Show(" ");
                string[] answers = File.ReadAllLines(t.path + "\\Answers.txt");

                for (int i = 0; i < 25; i++) // Starts at 4 to skip beginning of line
                {
                    tableData[i].Answers = answers[i+4].Substring(answers[i+4].IndexOf(".") + 1).ToString();
                    tableData[i].Quesetions = "LOLWHAT";
                    MessageBox.Show(tableData[i].Answers);
                }

                Table.ItemsSource = tableData.ToList().ToString();
            }
        }
    }
}
