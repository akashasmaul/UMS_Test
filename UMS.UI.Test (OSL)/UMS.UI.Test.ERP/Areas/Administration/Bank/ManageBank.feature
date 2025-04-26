Feature: Manage Bank


@CreateBank
@DataSource:../../../TestData/Administration/Excel/Bank.xlsx @DataSet:ManageBank
Scenario: T1 Create Bank Test
	Given Goto Manage Bank Page
	 When Click On Add Bank Button
	 Then Is Show Desired Test Page
	 When Enter Bank Full Name "<FullName>"
	  And Enter Bank Short Name "<ShortName>"
	  And Enter Bank Address "<Address>"
	  And Click On Bank Create Button
	 Then Is Show Action Success Message


@UpdateBank
@DataSource:../../../TestData/Administration/Excel/Bank.xlsx @DataSet:ManageBank
Scenario: T2 Update Bank Test
	Given Goto Manage Bank Page
	 When Enter Bank Full Name "<FullName>"
	  And Click On Bank Search Button
	  And Click On Update Glyph Icon
	 Then Is Show Desired Test Page
	 When Enter Bank Full Name "<FullName> v2"
	  And Enter Bank Short Name "<ShortName> v2"
	  And Enter Bank Address "<Address> v2"
	  And Click On Bank Update Button
	 Then Is Show Action Success Message


@DeleteBank
@DataSource:../../../TestData/Administration/Excel/Bank.xlsx @DataSet:ManageBank
Scenario: T3 Delete Bank Test
   Given Goto Manage Bank Page
	When Enter Bank Short Name "<ShortName> v2"
	 And Click On Bank Search Button
	 And Click On Delete Glyph Icon
	 And Click On Modal Danger Button
	Then Is Show Action Success Message