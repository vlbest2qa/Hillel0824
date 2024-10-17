Feature: FilteringTests
@mytag
Scenario: verify the product count after filtering
	Given open home page in FilteringTests
	When open solar cabels in menu in FilteringTests
	And count product before filtered
	And open filters
	And choose brand 'JA Solar' in filters
	And count product after filtered
	Then the quantity of products is different