Feature: CopyImage

@NeedsLogin
@DataSource:../../../../TestData/Student/Image/ImageCopy/ImageCopyData.xlsx @DataSet:Sheet1

@tag1
Scenario: CopyImage
	Given Go to Copy Image Page
	When Copy Image Page Loads
	And Click Increase Row Button "<RowCount>"
	And Select Organization Dropdown "<Organization>"
	And Select Program Dropdown "<Program>"
	And Select Session Dropdown "<Session>"
	And Select Target Organization Dropdown "<TargetOrganization>"
	And Select Target Program Dropdown "<TargetProgram>"
	And Select Target Session Dropdown "<TargetSession>"
	And Remove All Extra Target Rows Without Values
	And Get Status
	And Click Copy Image Button
	Then A Validation Message will Appear
