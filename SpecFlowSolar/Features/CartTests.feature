Feature: CartTests
@mytag
Scenario: add and delete product and return to home
	Given open home page in CartTests
	When open solar cabels in menu in CartTests
	And add to cart one product with index 1
	And go to cart in modal
	And remove product from cart if one
	Then is current url equal home
	And is title displayed
	And home page title name should be 'Магазин'