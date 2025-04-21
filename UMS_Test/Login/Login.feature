Feature: Erp Login


@LoginTest
Scenario: Erp Login Test
	Given Goto Login Page
	#Then Show the Login Page
	#When Click on the email field
	 When Enter email in the field
	#When Click on the password field
	  And Enter password in the field
	  And Click on the submit button
	 Then Is Success Login


@LogoutTest
Scenario: Erp Logout Test
    Given The user is already logged in
     When The user clicks the logout button
     Then Assert that user is redirected to login page