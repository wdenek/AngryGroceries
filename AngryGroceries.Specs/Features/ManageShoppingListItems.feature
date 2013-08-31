Feature: Keep track of groceries
	As a shopper you can keep track of your groceries using a shopping list.
	You can add, remove and edit items. Items you have in your basket can 
	be marked as completed. Made a mistake? Simply unmark the item and it is
	back on the list to get.

Background:
	Given I am logged on as a shopper
	And I have a shopping list "list of groceries"
	
Scenario: Add item to the shopping list
	Given I have not added "Pickles"
	When I add "Pickles" 
	Then I see "Pickles" in the uncompleted items list
	
Scenario: Remove item from the shopping list
	Given I have added "Pickles" to the shopping list 
	When I remove "Pickles" from the shopping list 
	Then I no longer see "Pickles" on the shopping list 
	
Scenario: Edit item on the shopping list
	Given I have added "Pickles" to the shopping list 
	When I change "Pickles" into "Gherkins" 
	Then I see "Gherkins" on the shopping list
	
Scenario: Mark item on the shopping list as completed
	Given I have added "Pickles" to the shopping list 
	When I mark "Pickles" as completed
	Then I no longer see "Pickles" as uncompleted on the shopping list
	And I see "Pickles" as completed on the shopping list

Scenario: Mark item on the shopping list as uncompleted
	Given I have added "Pickles" to the shopping list 
	And I have marked "Pickles" as completed
	When I mark "Pickles" as uncompleted
	Then I no longer see "Pickles" as completed on the shopping list
	And I see "Pickles" as uncompleted on the shopping list