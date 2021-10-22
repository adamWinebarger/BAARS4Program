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
    /* 
     * This class allows the user to take the BAARS 4 test and then saves all their information 
     * into a text file in their directory
     * */
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

        // Loads the next question and stores the current answer 
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (StoreAnswer())
            {
                NextQuestion();
                CheckButtonVisibility();
            } else
            {
                MessageBox.Show("Error! No button selected. Please select a valid value", "response");
            }
        }

        // Goes to the previous question and resets the radio buttons
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            count--;
            questionLabel.Content = lines[count];
            ResetRadioButtons();
            CheckButtonVisibility();
        }

        // Scores the test and closes the window
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreTest();
            Close();
        }

        // Displays the next question and resets the radio buttons
        void NextQuestion()
        {
            count++;
            questionLabel.Content = lines[count];
            ResetRadioButtons();
        }

        // Stores the answer into the answer array
        bool StoreAnswer()
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

        // Hides the back button if there is no previous questions and shows submit question when all questions are answered
        void CheckButtonVisibility()
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

        // Sets all the radio buttons to unchecked
        void ResetRadioButtons()
        {
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
            radioButton4.IsChecked = false;
        }


        // Calculates the score using the ScoreBAARS class and writes those results to the appropriate file
        void ScoreTest()
        {
            ScoreBAARS score;

            if (type == TestType.adult)
            {
                score = new ScoreBAARSAdult(answers);
                WriteAdultResults2TextFile((ScoreBAARSAdult)score);

            } else if (type == TestType.youth)
            {
                score = new ScoreBAARSYouth(answers);
                WriteYouthResults2TextFile((ScoreBAARSYouth)score);
            } else
            {
                return;
            }

            SaveAnswers2TextFile(score);
        }

        void SaveAnswers2TextFile(ScoreBAARS score)
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

        void WriteAdultResults2TextFile(ScoreBAARSAdult score)
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
                            score.GetSectionTotal(i).ToString());
                        writer.WriteLine("Section {0} symptoms count: {1}", i.ToString(),
                            score.GetSymptomTotal(i));
                    }

                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("Sum of raw scores section 1 thru 3: " + score.getOther("total1thru3").ToString());
                    writer.WriteLine("Section 1 Symptoms count: " + score.GetSymptomTotal(1).ToString());
                    writer.WriteLine("Sum  pf sections 2 and 3 symptoms count: " + score.getOther("symptom23").ToString());
                    writer.WriteLine("Total ADHD Symptoms count (1-3): " + score.getOther("symptom13").ToString());
                    writer.WriteLine("SCT Symptoms Count: " + score.GetSymptomTotal(4).ToString());
                }
            }
        }

        // Saves the results from the youth test to a file in their directory
        void WriteYouthResults2TextFile(ScoreBAARSYouth score)
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
                        writer.WriteLine("{0}{1}", displayValues[i], score.GetValue(inputValues[i]).ToString());
                    }
                }
            }
        }

    }
}
