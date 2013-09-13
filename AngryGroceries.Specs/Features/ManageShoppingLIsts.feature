Feature: Manage shopping lists
	There's a good possibility you will want to work with multiple shopping lists.
	One for the groceries and one for the DIY materials you still need.
	Multiple shopping lists are supported and you can share them with your friends and family.

Background:
	Given I am logged on as a shopper

Scenario: Create a new shopping list
	When I create a new shopping list
	And I enter the name "My second groceries list"
	And I accept the settings for the new shopping list
	Then I see the shopping list "My second groceries list"
	
Scenario: Edit the name of a shopping list
	Given I have a shopping list "Shipping list"
	When I edit the shopping list
	And I change the name to "Shopping list"
	And I accept the settings for the shopping list
	Then I see the shopping list "My shopping list"

Scenario: Removing a shopping list selects the first existing list

	A user can remove a shopping list. If there's another existing list,
	make sure that the list is selected, so that the user can continue working.

	Given I have the following shopping lists
	
	| name                |
	| Other shopping list |
	| Shopping list       |
	 
	And I have selected "Shopping list"
	When I delete the shopping list
	Then The shopping list "Other shopping list" is selected

Scenario: Removing the last shopping lists displays the Create new button
	
	Given I have a shopping list "list of groceries"
	When I delete the shopping list
	Then the create new button is displayed