Feature: TandM
	In order to be able to manage time and material
	As a turn up user
	I want to like to have a feature that enables me to add time and material

@mytag
Scenario: Create Time and Material Record
	Given Create Time and Material
	And I have logged in to the TurnUp Portal
	Then I should be able to create Time and Material

	Scenario: Edit Time and Material Record
	Given Create Time and Material
	And I have logged in to the TurnUp Portal
	Then I should be able to edit Time and Material

	Scenario: Delete Time and Material Record
	Given Create Time and Material
	And I have logged in to the TurnUp Portal
	Then I should be able to Delete Time and Material