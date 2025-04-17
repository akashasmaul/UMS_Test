Feature: ImageDownload

@NeedsLogin
@DataSource:../../../../TestData/Student/Image/ImageDownload/ImageDownloadData.xlsx @DataSet:Sheet1

@tag1
Scenario: DownloadImage
	Given Go to Image Download Page
	When Image Download Page Loads
	And Select "<Organization>" Organization
	And Select "<Program>" Program
	And Select "<Session>" Session
	And Select "<Course>" Course
	And Select "<Gender>" Gender
	And Select "<Version>" Version
	And Select "<Branch>" Branch
	And Select "<Campus>" Campus
	And Select "<BatchType>" BatchType
	And Select "<BatchTime>" BatchTime
	And Select "<Batch>" Batch
	And Click Count Button and Get Counts
	And Click Image Download Button "Yes"
