Feature: Feature1

A short summary of the feature

@smoketest
Scenario: Verify Search ABN
	Given The user is in ABN search page
	When The user search for an ABN
		| ABN Name        |
		| Business Switch |
	Then The ABN details should be displayed
