Feature: Studnet Admission


@NeedsLogin
@DataSource:../../../TestData/Student/Admission/AdmissionData.xlsx @DataSet:Admission

Scenario: New Student ReqEnroll
	Given User navigates to Student Admission Page
	When Enter The Student Nickname "<NickName>"
	And Enter The Student Mobile Number "<MobileNumber>"
	And Select Student Gender "<Gender>"
	And Select Student Religion "<Religion>"
	And Select Student Class "<Class>" Type
	And Select Student Program "<Program>" Name
	And Select Session "<Session>" Of Program
	And Search Last Educational Institute "<LastInstitute>"
	And Select Study Version "<StudyVersion>" Type
	And Select Branch Name "<Branch>" Of Program
	And Select Attched Physical Branch "<PhysicalBranch>" if Available
	And Select Campus Name "<Campus>" Of Branch
	And Click On Is Student Second Timer "<SecondTimerStatus>"
	And Click On Student Academic Group "<AcademicGroup>"
	And Select Course Name "<Course>" Of Program
	And Select Subject "<Subject>" Based on Course "<Course>"
	And Select Batch Type "<BatchType>" Of This Course
	And Select Batch Time "<BatchTime>" Of This Course
	And Select Batch Name Of This Course
	And Click On Admission Payment Next Button
	Then Show Admission Payment Details Section
	And Enter Special Discount "<SpecialDiscount>" Ammount
	And Select Special Discount "<DiscountBy>" Approved By
	And Select Special Discount "<DiscountType>" Type
	And Enter Special Discount "<DiscountNote>" Note
	When Enter Admission Received Amount "<RecievedAmount>"
	And Click On New Admission Submit Button
	Then Student should be successfully admitted

