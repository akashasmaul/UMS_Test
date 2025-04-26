Feature: Student Program Enrolment


@ProgramEnrolment
@DataSource:../../../../TestData/Student/Excel/Enrolment.xlsx @DataSet:Enroll
Scenario: Program Enrolment Test
	Given Goto Student Program Enrolment Page
	 When Select Student Program Class Type "<ClassType>"
	  And Click On Enroll Now Button "<Program>" "<Session>"
	  And Select Desire Course Name "<Course>"
	  And Click On Student Course Next Button
	  And Select Student Institute Name "<Institute>"
	  And Select Student Study Version "<Version>"
	  And Select Student Course Branch "<Branch>"
	  And Select Attached Physical Branch "<Branch>"
	  And Select Mbbs Or Dbs Second Time Status "<MbbsDbs>"
	  And Select Student Academic Study Group "<StudyGroup>"
	  And Select Course Batch Type, Time & Name "<Course>"
	  And Click On Course Payment Next Button
	  And Enter Student Payment Amount "<PaymentAmount>"
	  And Select Student Payment Method "<PaymentMethod>"
	  And Click On ProceedToPay Button With Terms&Condition
	  And Click On Ssl Commerz Payment Success Button
	 Then Is Success Student Program Course Enrollment
