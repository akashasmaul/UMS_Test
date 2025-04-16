Feature: ImageStatus

@NeedsLogin
@DataSource:../../../../TestData/Student/Image/ImageStatus/ImageStatusData.xlsx @DataSet:Sheet1


Scenario: Check Image Status
	Given Go to Image Status Page
	When Missing Image Page Loads
	And Select Organization "<Organization>"
	And Select Program "<Program>"
	And Select Session "<Session>"
	And Select Image Status "<ImageStatus>"
	And Select Courses "<Course>"
	And Select Gender "<Gender>"
	And Select Version "<Version>"
	And Select Branch "<Branch>"
	And Select Campus "<Campus>"
	And Select BatchType "<BatchType>"
	And Select BatchTime "<BatchTime>"
	And Select Batch "<Batch>"
	And Click Count Button and Get Count
	And Select Information "<Information>"
	And Remove Information "<RemoveInfo>"
	And Enter Reg No./Roll No. "<RegOrRoll>"
	And Enter Nickname "<NickName>"
	And Enter Mobile Number "<MobileNumber>"
	And Click View Button
	Then DataTable Should Appear
	And Export the DataTable "No"
