Feature: Create a place
In order to create a place
I am told to verify post user API
API - POST - add/json

@positivescenario
Scenario: Create a place
	Given the place details
		| accuracy | name     | phone_number       | address                   | types     | website           | language  |
		| 50       | mn house | (+91) 983 893 3937 | 30, side layout, cohen 09 | shoe park | http://google.com | French-IN |
	And the location details
		| lat        | lng       |
		| -38.383494 | 33.427362 |
	When the location details are passed
	Then the status should be 200