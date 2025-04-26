Feature: Student Mcq Live Exam


Scenario: Mcq Live Exam Test
	Given Goto Dashboard Live Exam
	 Then Is Show Desired Mcq Live Exam
	 When Click On Mcq Live Take Exam Button
	  And Select Mcq Live Examinee Study Version
	  And Click On Start Mcq Live Exam Button
	  And Assertion Start Mcq Live Exam Info
	  And Click On Mcq Live Exam Answer Options
	  And Click On Mcq Live Exam Submit Button
	 Then Is Success Mcq Live Exam Submission

