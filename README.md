# BAARS4Program

Main Window.xaml
- This file handles the design & code for the start menu of the program
- Menu options include take test, score test, and a table of people who have already taken the test

Test Info Window.xaml
- This file handles asks for all the user information in order to allow them to take the test
- TakeTestButton_Click() - Button to get user to take test, opens user information input window
- QuickScoreButton_Click() - Quickly calculate the score

Test Window.xaml
- This file handles the design & code for taking the test
- Allows the user to take the test, then saves their info and score to a file
- SubmitButton_Click() - Ensures all information is valid, creates directory for the tester & saves tester info to a file, then opens the test window
- AgeTextBox_TextChanged() - If Age isn't valid, show error and repromt for input
- MaleRadioButton_Checked() - Sets other radio button to not checked
- FemaleRadioButton_Checked() - Sets other radio button to not checked
- CheckRequiredFeilds() - Returns false if first name or last name are left blank, age isn't an int, and if radio buttons aren't checked
- AgeIsValid() - Returns true if Age is an INT, not blank, and not null
- CreateDirectory4Tester() - Creates the directory for all the users information and scores
- CreateTesterInfoTextFile() - Writes all the tester information into a text file in the users directory

Bars Scoring Classes

ScoreBAARS.cs
- This class contains two functions, total score and symptom count

ScoreBAARSYouth.cs
- This class extends ScoreBAARS.cs and determines the scores of the young ins

ScoreBAARSAdult.cs
- This class also extends ScoreBAARS.cs and determines the scores of the adults
