Feature: Teacher Portal Login


@TeacherLogin
Scenario: Teacher Login Test
	Given Goto Teacher Login Page
	 When Enter TPIN in The Field
	  And Enter Teacher Password
	  And Click on Teacher Login Button
	 Then Is Teacher Login Success


@TeacherLogout
Scenario: Teacher Logout Test
    Given The Teacher is already logged in
     When Teacher click the logout button
     Then Assert that Teacher goto login page