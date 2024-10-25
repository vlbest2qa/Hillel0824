Feature: FilteringTests

@filteringTests
Scenario: verify the product count after filtering 1
	Given open home page
	When open solar cabels in menu
	And count product before filtered
	And open filters
	And choose brand 'JA Solar' in filters
	And count product after filtered
	Then the quantity of products is different

@filteringTests
Scenario: verify the product count after filtering 2
	Given open home page
	When open solar cabels in menu
	And count product before filtered
	And open filters
	And choose brand 'JA Solar' in filters
	And count product after filtered
	Then the quantity of products is different