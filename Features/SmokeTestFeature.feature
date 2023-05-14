Feature: SmokeTestFeature
in order to get the home page display
As a user write url in the browser 
accept cookies navigate to other pages.
in result the page display, 

@homePage
Scenario: Display homePage
	When  I open the home page
	Then  The page is displayed

@homePage
Scenario: Contact page
	Given I have opened the home page
	And I have agreed to the cookie policy
	When I select Contact
	Then the Contact page is displayed

@linkFundSolutions
Scenario: Investment managers
	Given I have opened the Fund Solutions page
	When I view Funds
	Then I can select the investment managers for investors
	| Jurisdictions |
	| UK            |
	| Irish         |
	| Swiss         |
