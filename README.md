# BAARS4Program

Main Window.xaml.cs
- This file handles the design & code for the start menu of the program
- Menu options include take test, score test, and a table of people who have already taken the test
- TakeTestButton_Click() - Button to get user to take test, opens user information input window
- QuickScoreButton_Click() - Quickly calculate the score
- RefreshButton_Click() - Refreshes the datagrid - mainly for testing
- DeleteButton_Click() - Button to delete directories - mainly for testing
- showResultsButton_Click() - Opens the tester answers window for a user that is clicked on the datagrid
- ToggleAdvancedSearchButton_Click_1() - Shows the advanced search options to search by first, last, or middle name
- ReloadTable() - Upades the table anytime new content/new directories are made
- LoadDataIntoTable() - Populates the datagrid with all the people who have taken the test
- Table_AutoGenerateColumn() - Used to formate and style the table
- SearchBox_TextChanged() Researches table everytime the text in the search box is changed
- SearchTable() - Searches the table depending on first/middle/last name depending on user
- FirstName_Checked() - Researches the table through first name
- MiddleName_Checked() - Researches the table through middle name
- LastName_Checked() - Researches the table through the last name 
- Table_MouseDoubleClick() - Opens up a new window with the tester answers

Test Info Window.xaml.cs
- This file handles asks for all the user information in order to allow them to take the test
- SubmitButton_Click() - Ensures all information is valid, creates directory for the tester & saves tester info to a file, then opens the test window
- AgeTextBox_TextChanged() - If Age isn't valid, show error and repromt for input
- MaleRadioButton_Checked() - Sets other radio button to not checked
- FemaleRadioButton_Checked() - Sets other radio button to not checked
- CheckRequiredFeilds() - Returns false if first name or last name are left blank, age isn't an int, and if radio buttons aren't checked
- AgeIsValid() - Returns true if Age is an INT, not blank, and not null
- CreateDirectory4Tester() - Creates the directory for all the users information and scores
- CreateTesterInfoTextFile() - Writes all the tester information into a text file in the users directory

Test Window.xaml.cs
- This file handles the design & code for taking the test
- Allows the user to take the test, then saves their info and score to a file
- NextButton_Click() - Loads the next question and stores the current answer 
- BackButton_Click() - Goes to the previous question and resets the radio buttons
- SubmitButton_Click() - Scores the test and closes the window
- startTest() - Starts the test to allow users to answer questions and keep score
- NextQuestion() - Displays the next question and resets the radio buttons
- StoreAnswer() - Stores the answer into the answer array
- CheckButtonVisibility() - Hides the back button if there is no previous questions and shows submit question when all questions are answered
- ResetRadioButtons() - Sets all the radio buttons to unchecked
- multiBackComboBox_SelectionChanged() - Not entirely sure but something to do with keeping track of answers for question select
- updateMultiBackComboBox() - Not entirely sure but also has something to do with keep track of answers
- ScoreTest() - Calculates the score using the ScoreBAARS class and writes those results to the appropriate file
- SaveAnswers2Textfile() - Saves all the answers that the user put into a text file in their directory
- WriteAdultResults2TextFile() - Saves the adult scores for the test to a text file in their directory
- WriteYouthResults2TextFile() - Saves the youth scores for the test to a text file in their directory

Test Answers.xaml.cs
- This window opens up for a tester and allows you to show all their answers to the test aswell as answers from a parent
- OnWindowClosing() - Reincrypts the files on close
- showAdult_Click() - Shows all the questions and answers and results for the answers on the adult portion of the test
- showChild_Click() - Shows all the questions and answers and results for the answers on the child portion of the test
- showOther_Click() - Opens a window to show all the other times they might have taken the test or what their parents might have put down for their test
- getAnswers() - Get the answer information from the users answers text file and the questions and load it into a table\
- loadAdultResults() - Loads all the adult answers into a datagrid
- loadChildResults() - Loads all the child answers into a datagrid

OtherTestSelectionWindow.xaml.cs
- This window is opened in the test answers window to show other tests that a user might have taken or tests that their parents took for them 
- cancelButton_Click() - Closes the window
- okButton_Click() - Populates the answers on the answers window with the test they selected and then closes this window
- loadDataIntoTable() - Upon startup all the data for the other tests get loaded into the datagrid
- othersTable_SelectionChanged() - Repopulates the table when the selection changes
- Table_MouseDoubleClick() - Upon double click populate the answers window and close out of this
- populateOtherSelected() - Populates the table with the other tests

PTInfoWindow.xaml.cs
- This window is for the quick score function. It allows you to enter the information for a user to add another test to their database
- ComboBox_SelectionChanged() - Changes the visibility for some UI settings when certain elements for the combo box are selected
- SubmitButton_Click() - Pushes all their information that was entered to a text file and procedes to the quick score window
- allInputsValid() - Verfies everything is entered correctly in the textboxes and combo boxes
- makeOtherTestsDirectory() - Makes the directory for the new tests

PTQuickScoreWindow.xaml.cs
- adultAnswersInputTextBox_TextChanged() - When new text is added advance to next question or go back/forward depending on character input, also checks for invalid input
- childAnswersInputTextbox_TextChanged() - When new text is added advance to next question or go back/forward depending on character input, also checks for invalid input
- finishButton_Click() - Closes the window
- updateQuestionNumberLabel() - Everytime a new question is reached show that on the label
- createRelationalDirectory() - Create the new directory based on the relation of the person to the tester
- createAnswersTextfile() - Puts all the answers into a text file in the new directory 
- createAdultResultsTextFile() - Puts all the answers to the adult section of the text into a text file
- createChildResultsTextFile() - Puts all the answers to the child section of the text into a text file

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
