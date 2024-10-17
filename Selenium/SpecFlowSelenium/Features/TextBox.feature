Feature: TextBox

@mytag
Scenario: Fill form with valid data
	Given Open Text Box page
	When Fill Full Name 'Kotelevets Vladyslav'
	And Fill Email 'myemail@gmail.com'
	And Fill Curren t Adress '4B Serpova street, Kharkiv, Ukraine'
	And Fill Permanent Adress '8 Berejnia street, Vasisheve, Ukraine'
	And Click Submit Button
	Then Output Name should be 'Name:Kotelevets Vladyslav'