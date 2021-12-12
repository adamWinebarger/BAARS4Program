# BAARS4Program

Main Window.xaml
- This file handles the design & code for the start menu of the program
- Menu options include take test, score test, and a table of people who have already taken the test
- TakeTestButton_Click() - Button to get user to take test, opens user information input window
- QuickScoreButton_Click() - Quickly calculate the score
- 
Test Info Window.xaml
- This file handles asks for all the user information in order to allow them to take the test
- SubmitButton_Click() - Ensures all information is valid, creates directory for the tester & saves tester info to a file, then opens the test window
- AgeTextBox_TextChanged() - If Age isn't valid, show error and repromt for input
- MaleRadioButton_Checked() - Sets other radio button to not checked
- FemaleRadioButton_Checked() - Sets other radio button to not checked
- CheckRequiredFeilds() - Returns false if first name or last name are left blank, age isn't an int, and if radio buttons aren't checked
- AgeIsValid() - Returns true if Age is an INT, not blank, and not null
- CreateDirectory4Tester() - Creates the directory for all the users information and scores
- CreateTesterInfoTextFile() - Writes all the tester information into a text file in the users directory

Test Window.xaml
- This file handles the design & code for taking the test
- Allows the user to take the test, then saves their info and score to a file
- NextButton_Click() - Loads the next question and stores the current answer 
- BackButton_Click() - Goes to the previous question and resets the radio buttons
- SubmitButton_Click() - Scores the test and closes the window
- NextQuestion() - Displays the next question and resets the radio buttons
- StoreAnswer() - Stores the answer into the answer array
- CheckButtonVisibility() - Hides the back button if there is no previous questions and shows submit question when all questions are answered
- ResetRadioButtons() - Sets all the radio buttons to unchecked
- ScoreTest() - Calculates the score using the ScoreBAARS class and writes those results to the appropriate file
- SaveAnswers2Textfile() - Saves all the answers that the user put into a text file in their directory
- WriteAdultResults2TextFile() - Saves the adult scores for the test to a text file in their directory
- WriteYouthResults2TextFile() - Saves the youth scores for the test to a text file in their directory
- lastNameCheckBox() - Checks the last name and sees if it was found for the search table
- middleNameCheckBox() - Checks the middle name and sees if it was found for the search table
- firstNameCheckBox() - Checks the first name and sees if it was found for the search table


Bars Scoring Classes

ScoreBAARS.cs
- This class contains two functions, total score and symptom count
- TotalScore() - Adds up all the answer scores to the total score
- SymptomCount() - Determines the total number of symptoms

ScoreBAARSYouth.cs
- This class extends ScoreBAARS.cs and determines the scores of the young ins
- getValue() - Gets the number value of total1, total2, symptom1, symptom2, sumtotal, and sumSymptoms

ScoreBAARSAdult.cs
- This class also extends ScoreBAARS.cs and determines the scores of the adults
- GetSectionTotal() - Returns the secotion total 1, 2, 3, or 4, depending on which section is given
- GetSymptomTotal() - Returns the symptom total depending on the section
