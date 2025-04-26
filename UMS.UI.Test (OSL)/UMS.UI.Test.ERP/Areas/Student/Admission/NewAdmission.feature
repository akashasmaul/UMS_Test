@StudentAdmission
Feature: Student Admission

#Background:
#	Given Login with email "<Email>" and password "<Password>"
#Examples:  
#		| Email                | Password |
#		| tauhid@onnorokom.com | #######  |


@NewStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:NewAdmission
Scenario: T1.0 New Student Admission Test
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 #Then Select Educational Institute Name
	  And Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	  #And Select Course Name Of This Program
	  #And Select Batch Type Of This Course
	  #And Select Batch Time Of This Course
	  #And Select Batch Name Of This Course
	  #And Click On Subject Unchecked Box
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Admission Received Amount "<Received>"
	 When Select Next Payment Receive Date
	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
	  And Evaluate Admission Money Receipt Data


@ComplementaryOldStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:Complementary
Scenario: T1.1 Old Admission In Complementary Course
	Given Goto New Or Old Student Admission
	 When Enter Student RegOrRoll Number "<RegOrRoll>"
	  And Navigate Old Student Admission
	 Then Shown Old Student Admission Page
	 When Enter The Student Mobile Number "<Mobile>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 When Click On Complementary Course Name "<ComplementaryCourse>"
	 When Click On Confirm Button In Modal
	 Then Is Show Complementary Course List
	 When Select Study Version "<Version>" Type
	  And Select Branch Name "<AttachedBranch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Admission Received Amount "<Received>"
	 When Select Next Payment Receive Date
	  And Click On Old Admission Submit Button
	 Then Shown Admitted Money Receipt Page
	  And Evaluate Admission Money Receipt Data


@OldStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:OldAdmission
Scenario: T1.2 Old Student Admission In Regular Course
	Given Goto New Or Old Student Admission
	 When Enter Student RegOrRoll Number "<RegOrRoll>"
	  And Navigate Old Student Admission
	 Then Shown Old Student Admission Page
	 When Enter The Student Mobile Number "<Mobile>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 When Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Admission Received Amount "<Received>"
	 When Select Next Payment Receive Date
	  And Click On Old Admission Submit Button
	 Then Shown Admitted Money Receipt Page
	  And Evaluate Admission Money Receipt Data


@OldStudentAdmissionInSameProgram
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:OldAdmission
Scenario: T1.3 Old Admission in Same Program Session
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	  And Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Admission Received Amount "<Received>"
	  And Select Next Payment Receive Date
	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
	  And Evaluate Admission Money Receipt Data
	Given Goto New Or Old Student Admission
	 When Enter Student RegOrRoll Number "<RegOrRoll>"
	  And Navigate Old Student Admission
	 Then Shown Old Student Admission Page
	 When Enter The Student Mobile Number "<Mobile>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 When Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	 Then Can Take Any Course of This Program


@SpecialDiscountNewStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:OldAdmission
Scenario: T1.4 Special Discount New Student Admission
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 When Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Special Discount "<Discount>" Amount
	  And Select Special Discount Approved By "<ApprovedBy>"
	 #And Select The Special Discount Approver
	  And Select Special Discount Type "<DiscountType>"
	  And Select Special Discount Referred By "<ReferredBy>"
	 #And Select The Special Discount Referrer
	  And Enter Admission Special Discount Note
	  And Enter Admission Received Amount "<Received>"
	  And Select Next Payment Receive Date
 	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
  	  And Evaluate Admission Money Receipt Data


@FullPaymentNewStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:FullPayment
Scenario: T1.5 Full Paid New Student Admission
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	  And Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Full Receivable Amount "<Received>"
	  And Select Next Payment Receive Date
	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
	  And Evaluate Admission Money Receipt Data


@FullDiscountNewStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:FullDiscount
Scenario: T1.6 Full Discount New Student Admission
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 When Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	  And Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Full Discount Amount For Top Student
	  And Select Special Discount Approved By "<ApprovedBy>"
	  And Select Special Discount Type "<DiscountType>"
	  And Select Special Discount Referred By "<ReferredBy>"
	  And Enter Admission Special Discount Note
	  And Enter Admission Received Amount "<Received>"
	  And Select Next Payment Receive Date
 	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
  	  And Evaluate Admission Money Receipt Data
	 

@OverMinAmountNewStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:Sp_Discount
Scenario: T1.7 Minimum Amount Over Payable Amount New Admission
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 When Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Select Course Name "<Course>" Of Program
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Special Discount "<Discount>" Amount
	  And Select Special Discount Approved By "<ApprovedBy>"
	  And Select Special Discount Type "<DiscountType>"
	 #And Select Special Discount Referred By "<ReferredBy>"
	  And Enter Admission Special Discount Note
	  And Enter Admission Received Amount "<Received>"
	  And Select Next Payment Receive Date
 	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
  	  And Evaluate Admission Money Receipt Data


@ComplementaryNewStudentAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:Complementary
Scenario: T1.8 New Admission in Complementary Course
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	 When Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  And Click On Complementary Course Name "<ComplementaryCourse>"
	 When Click On Confirm Button In Modal
	 Then Is Show Complementary Course List
	 When Select Branch Name "<AttachedBranch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Select Course Name "<Course>" Of Program
	 When Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Admission Received Amount "<Received>"
	  And Select Next Payment Receive Date
	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
	  And Evaluate Admission Money Receipt Data


@SpinNewAdmission
@DataSource:../../../TestData/Student/Excel/AdmissionData.xlsx @DataSet:SpinAdmission
Scenario: T1.9 Spin New Student Admission Test
	Given Navigate New Student Admission
	 Then Shown New Student Admission Page
	 When Enter The Student Nickname "<Nickname>"
	  And Enter The Student Mobile Number "<Mobile>"
	  And Select Student Gender "<Gender>"
	  And Select Student Religion "<Religion>"
	  And Select Student Class "<Class>" Type
	  And Select Student Program "<Program>" Name
	  And Select Session "<Session>" Of Program
	  And Search Educational Institute Name
	  And Select Study Version "<Version>" Type
	  And Select Branch Name "<Branch>" Of Program
	  And Select Campus Name "<Campus>" Of Branch
	  And Click On Is Student Second Timer "<Timer>"
	  And Click On Student Academic Group "<Group>"
	  #And Select Course Name "<Course>" Of Program
	  And Select Course Name "<Course>"
	  And Select Batch Type Of This Course
	  And Select Batch Time Of This Course
	  And Select Batch Name Of This Course
	  And Click On Admission Payment Next Button
	 Then Show Admission Payment Details Section
	 When Enter Admission Received Amount "<Received>"
	  And Select Next Payment Receive Date
	  And Click On New Admission Submit Button
	 Then Shown Admitted Money Receipt Page
	  And Evaluate Admission Money Receipt Data
	 When Bulk Spin New Student Admission "<Count>"
