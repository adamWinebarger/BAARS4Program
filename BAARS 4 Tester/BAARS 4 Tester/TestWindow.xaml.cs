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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private string firstname, lastname, middlename = " ", gender, path;
        private int age;
        private string[] lines;
        private int[] answers;
        private TestType type;

        private string questionPath = "BAARS4Questions";

        private int count = 0, maxCount;
        

        public TestWindow(TestType type, string firstname, string lastname, string middlename, string gender,
                string path, int age)
        {
            InitializeComponent();

            this.firstname = firstname;
            this.lastname = lastname;
            this.gender = gender;
            this.path = path;
            this.age = age;
            this.type = type;

            if (middlename != "" && middlename != null)
            {
                this.middlename = middlename;
            }

            backButton.Visibility = Visibility.Hidden;
            submitButton.Visibility = Visibility.Hidden;

            if (type == TestType.adult)
            {
                questionPath += "\\Adult_Questions.txt";
                maxCount = 27;
            } else
            {
                questionPath += "\\Child_Questions.txt";
                maxCount = 18;
            }

            lines = File.ReadAllLines(questionPath);
            answers = new int[maxCount];
            questionLabel.Content = lines[0];
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (storeAnswer())
            {
                nextQuestion();
                checkButtonVisibility();
            } else
            {
                MessageBox.Show("Error! No button selected. Please select a valid value", "response");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            count--;
            questionLabel.Content = lines[count];
            resetRadioButtons();
            checkButtonVisibility();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            scoreTest();
            Close();
        }

        void nextQuestion()
        {
            count++;
            questionLabel.Content = lines[count];
            resetRadioButtons();
        }

        bool storeAnswer()
        {
            if ((bool)radioButton1.IsChecked)
            {
                answers[count] = 1;
            } else if ((bool)radioButton2.IsChecked)
            {
                answers[count] = 2;
            } else if ((bool)radioButton3.IsChecked)
            {
                answers[count] = 3;
            } else if ((bool)radioButton4.IsChecked)
            {
                answers[count] = 4;
            } else
            {
                return false;
            }

            return true;
        }

        void checkButtonVisibility()
        {
            if (count > 0)
            {
                backButton.Visibility = Visibility.Visible;
            } else
            {
                backButton.Visibility = Visibility.Hidden;
            }

            if (count == maxCount)
            {
                nextButton.Visibility = Visibility.Hidden;
                submitButton.Visibility = Visibility.Visible;
            } else
            {
                nextButton.Visibility = Visibility.Visible;
                submitButton.Visibility = Visibility.Hidden;
            }
        }

        void resetRadioButtons()
        {
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
            radioButton4.IsChecked = false;
        }

        void scoreTest()
        {
            ScoreBAARS score;

            if (type == TestType.adult)
            {
                score = new ScoreBAARSAdult(answers);
                writeAdultResults2TextFile((ScoreBAARSAdult)score);

            } else if (type == TestType.youth)
            {
                score = new ScoreBAARSYouth(answers);
                writeYouthResults2TextFile((ScoreBAARSYouth)score);
            } else
            {
                return;
            }

            saveAnswers2Textfile(score);
        }

        void saveAnswers2Textfile(ScoreBAARS score)
        {
            string answersTextfile = path + "\\Answers.txt";

            if (!File.Exists(answersTextfile))
            {
                using (StreamWriter writer = File.CreateText(answersTextfile))
                {
                    writer.WriteLine("Name: {0}, {1} {2}", lastname, firstname, middlename);
                    writer.WriteLine("Age: {0}    Gender: {1}", age.ToString(), gender);
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("Answers: ");

                    for (int i = 0; i < answers.Length; i++)
                    {
                        writer.WriteLine((i + 1).ToString() + ". " + answers[i].ToString());
                    }
                }
            }
        }

        void writeAdultResults2TextFile(ScoreBAARSAdult score)
        {
            string resultsFile = path + "\\adultResults.txt";

            if (!File.Exists(resultsFile))
            {
                using (StreamWriter writer = File.CreateText(resultsFile))
                {
                    writer.WriteLine("Name: {0}, {1} {2}", lastname, firstname, middlename);
                    writer.WriteLine("Age: {0}    Gender: {1}", age.ToString(), gender);
                    writer.WriteLine("Adult results");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("Section Results: ");

                    for (int i = 1; i <= 4; i++)
                    {
                        writer.WriteLine("Section {0} raw score: {1}", i.ToString(), 
                            score.getSectiontotal(i).ToString());
                        writer.WriteLine("Section {0} symptoms count: {1}", i.ToString(),
                            score.getSymptomTotal(i));
                    }

                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("Sum of raw scores section 1 thru 3: " + score.getOther("total1thru3").ToString());
                    writer.WriteLine("Section 1 Symptoms count: " + score.getSymptomTotal(1).ToString());
                    writer.WriteLine("Sum  pf sections 2 and 3 symptoms count: " + score.getOther("symptom23").ToString());
                    writer.WriteLine("Total ADHD Symptoms count (1-3): " + score.getOther("symptom13").ToString());
                    writer.WriteLine("SCT Symptoms Count: " + score.getSymptomTotal(4).ToString());
                }
            }
        }

        void writeYouthResults2TextFile(ScoreBAARSYouth score)
        {
            string resultsFile = path + "\\childResults.txt";

            string[] inputValues = { "total1", "symptom1", "total2", "symptom2", "sumTotal", "sumSymptoms" },
                displayValues = { "Section 1 Total Score: ", "Section 1 Symptoms Count: ",
                    "Section 2 Total Score: ", "Section 2 Symptoms Count: ", "Sum of Sections 1-2 Total Score: ",
                    "Sum of Sections 1-2 Symptoms Count: "};

            if (!File.Exists(resultsFile))
            {
                using (StreamWriter writer = File.CreateText(resultsFile))
                {
                    writer.WriteLine("Name: {0}, {1} {2}", lastname, firstname, middlename);
                    writer.WriteLine("Age: {0}    Gender: {1}", age.ToString(), gender);
                    writer.WriteLine("Child results");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    ///writer.WriteLine("Section Results: ");

                    for (int i = 0; i < inputValues.Length; i++)
                    {
                        writer.WriteLine("{0}{1}", displayValues[i], score.getValue(inputValues[i]).ToString());
                    }
                }
            }
        }

    }
}
