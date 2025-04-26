Feature: Student MyDue

@StudentMyDue
Scenario: Student Due Payment
	Given Navigate Student Due Payment
	And Click On Pay Now Button
	And Extract Due Amount
	And Enter Payment Amount
	And Click On bKash Web Payment
	And Click On  Agree Terms And Condition
	And Click On Proceed to Pay Button
	And Click On Success Button
	Then Show Course Success Message

