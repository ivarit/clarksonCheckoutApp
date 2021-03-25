Feature: Order
	

@mytag
Scenario Outline:Add an item to order
	Given I am presented with menu
	When I add below items
	| menuItem |
	| A    |
	| B    |
	| C    |
	Then I should be presented with total "<totalBill>"
Examples: 
	| totalBill |
	| 15.80     |
	| 10.00     |


	