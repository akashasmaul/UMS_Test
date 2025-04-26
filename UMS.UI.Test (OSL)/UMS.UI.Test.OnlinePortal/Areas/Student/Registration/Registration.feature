Feature: Student Portal Registration

A short summary of the feature

@StudentRegistration
@DataSource:../../../../UMS.UI.Test.OnlinePortal/TestData/Student/Excel/Registration.xlsx @DataSet:registrationinfo
Scenario: 01 Student Registration Test
	Given Goto Student Registration Page
	 When Click on the Register Now
	 Then Show Registration Form Page
	 When Enter Nick Name in the field
	  And Enter Mobile Number in the field
	  And Click on the Next Button
	 Then Show OTP Page
	 When Enter OTP in the field
	 #When Click Resend OTP Button
	 And Click on the OTP Next Button
	 Then Show Academic Page
	 When Select Grade or Level DropDown "<GradeOrLevel>"
	 And Select Gender DropDown "<Gender>"
	 And Select Religion DropDown "<Religion>"
	 And Select District DropDown "<District>"
	 And Enter Email in the field "<Email>"
	 And Click on the Submit Button
	 Then Show Set Your Password Page
	 When Enter New Password in the field "<Password>"
	 And Enter Confirm Password in the field
	 And Click on the Set Password Submit Button
	 Then Show Program List Page

@ForgotRegistrationNumber
Scenario: 02 Student Forgot Registration Number Test
	Given Goto Student Registration Page
	 When Click on the Forgot Registration Number
	 Then Show Forgot Registration Number Form Page
	 When Enter Forgot Registration Nick Name in the field
	  And Enter Forgot Registration Mobile Number in the field
	  And Click on the Forgot Registration Next Button
	 Then Show Forgot Registration OTP Page
	 When Enter Forgot Registration OTP in the field
	 And Click on the Forgot Registration OTP Next Button
	 Then Show Congratulations Page

@ForgotPassword
Scenario: 03 Student Forgot Password Test
	Given Goto Student Portal Login Page
	 When Enter Registration Number in the field
	  And Click on the Student Login Next button
	  Then Show Forgot Password Text
	  When Click on the Forgot Password Link
	  And Enter Forgot Password Registration Number in the field
	  And Enter Forgot Password Mobile Number in the field
	  And Click on the Forgot Password Next button
	 Then Show Forgot Password OTP Page
	 When Enter Forgot Password OTP in the field
	 And Click on the Forgot Password OTP Next Button
	 When Enter New Password in the field "<Password>"
	 And Enter Confirm Password in the field
	 And Click on the Set Password Submit Button
	 Then Show Login Button

@RegistrationResendOTP
Scenario: 04 Student Registration Resend OTP Test
	Given Goto Student Registration Page
	 When Click on the Forgot Registration Number
	 Then Show Forgot Registration Number Form Page
	 When Enter Forgot Registration Nick Name in the field
	  And Enter Forgot Registration Mobile Number in the field
	  And Click on the Forgot Registration Next Button
	 Then Show Forgot Registration OTP Page
	 When Click Resend OTP Button
	 When Enter Forgot Registration OTP in the field
	 And Click on the Forgot Registration OTP Next Button
	 Then Show Congratulations Page