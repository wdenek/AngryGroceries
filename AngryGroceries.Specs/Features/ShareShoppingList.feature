Feature: Sharing a shopping list
	You can share shopping lists with friends and family to work together on a single shopping list.

Background: 
	I am logged on as a shopper

Scenario: Share a shopping list with someone
	Given I have a shopping list "list of groceries"
	When I share the shopping list
	When I enter the emailaddress "someuser@email.com"
	Then the shopping list is shared with the user having e-mailaddress "someuser@email.com" 

Scenario: Share a shopping list with someone without a user account
	Given I have a shopping list "list of groceries"
	When I share the shopping list
	When I enter the emailaddress "someuser@otherdomain.com"
	Then the user with e-mailaddress "someuser@otherdomain.com" gets an invitation to create an account and join the shopping list

Scenario: Stop sharing the shopping list with someone as an owner of the shopping list
	Given I have a shopping list "list of groceries"
	And I have shared the shopping list with "someuser@domain.com" 
	When I share the shopping list
	And I remove "someuser@domain.com" 
	Then the shopping list is no longer shared with "someuser@domain.com" 

Scenario: Remove shopping list that was shared with me
	Given "someuser@domain.com" shared "list of groceries" with me
	When I remove the shopping list
	Then the shopping list is no longer shared with me