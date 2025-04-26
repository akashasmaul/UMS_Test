Feature: OpeningBalance

@DataSource:../../../../TestData/Teacher/Excel/TeacherActivity.xlsx @DataSet:OpeningBalance
Scenario: SetOpeningBalance
	Given Go to Opening Balance Page
	When Select Organization "<Organization>" for OBalance
	When Enter TPIN [TeacherId] "<TPIN>" for Opening Balance
	And Click View Button for Opening Balance
	And Verify total teacher count matches with TPIN count for OB
	And Select Date "<OpeningDate>" for Opening Balance
	When Enter Total Class "<ClassNumber>" for each Teacher "<TPIN>" for Opening Balance
	And Click Save Opening Balance Button
	Then Opening Balance will be Saved Successfully.
