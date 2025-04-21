Feature: Area Common

Scenario: Area Common Test Cases

	 When Select Organization "<Organization>"
	 When Multi Select Organization "<Organization>" With AttributeId "OrganizationId"

	 When Select Program "<Program>"
	 When Multi Select Program "<Program>" With AttributeId "ProgramId"

	 When Select Session "<Session>"
	 When Multi Select Session "<Session>" With AttributeId "SessionId"

	 When Select Course "<Course>"
	 When Multi Select Course "<Course>" With AttributeId "CourseId"

	 When Select Branch "<Branch>"
	 When Multi Select Branch "<Branch>" With AttributeId "BranchId"

	 When Select Start Date From "<StartDate>"
	 When Select End Date To "<EndDate>"
	 
	 When Select Start Date From "<StartDate>"  With AttributeId "attributeId"
	 When Select End Date To "<EndDate>" With AttributeId "attributeId"

	 When Select Information To View All

	 When Click On Update Glyph Icon
	 When Click On Delete Glyph Icon

	 When Click On Modal Success Button
	 When Click On Modal Danger Button

	 Then Is Show Desired Test Page
	 Then Is Show Action Success Message
	 Then Is Show Action Failure Message
