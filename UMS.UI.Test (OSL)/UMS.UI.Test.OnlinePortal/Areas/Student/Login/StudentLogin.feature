Feature: Student Portal Login


@StudentLogin
Scenario: Student Login Test
	Given Goto Student Login Page
	 When Enter Registration No. in the field
	  And Click on the Next button
	  And Enter Password in the field
	  And Click on Student Login button
	 Then Is Student Login Success


@StudentLogout
Scenario: Student Logout Test
    Given The student is already logged in
     When The student click the logout button
     Then Assert that student is goto login page