Feature: Student Online Written Exam


@TakeOnlineWrittenExam
Scenario: Take Online Written Exam Test
	Given Goto Online Written Exam Section
	 When Click On Online Written Exam Section
	 Then Is Show Desired Online Written Exam
	 When Click On Online Written Take Exam Button
	  And Select Examinee Online Written Study version
	  And Click On Online Written Start Exam Button
	 Then Show Online Written Exam Information
	 When Online Written Take Examination
	 Then Take Examination Successful

#Scenario: Live Online Written Exam Availability Test
#	Given Goto Online Written Exam Section
#	 When Click On Online Written Exam Section
#	 Then Is Show Desired Live Online Written Exam
