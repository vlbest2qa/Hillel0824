Feature: CartTests

@cartTests
Scenario: add and delete product and return to home 1
	Given open home page
	When open solar cabels in menu
	And add second product to cart
	And go to cart in popup window
	And remove product from cart
	Then current url is equal to home url
	And title is displayed
	And home page title name is 'Магазин'

@cartTests
Scenario: add and delete product and return to home 2
	Given open home page
	When open solar cabels in menu
	And add second product to cart
	And go to cart in popup window
	And remove product from cart
	Then current url is equal to home url
	And title is displayed
	And home page title name is 'Магазин'