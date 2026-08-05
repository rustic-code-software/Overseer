Feature: Create an account

As an endpoint user
I want to create a new Account
So that I can create other services

@MockAccountActiveRecord @MockAccountPubSub
Scenario: Successfully creating a new individual account with valid details supplied
	Given that that the endpoint request has been made with valid details for an individual account
		| FirstName | LastName | Email             | Password |
		| John      | Doe      | john.doe@test.com | P@55w0rd |
	When the request is posted to the account creation endpoint
	Then the response should indicate success with a 202 Accepted
	And the response body should contain the new Account ID
	And the response body should contain a URI to the accounts status endpoint
@MockAccountActiveRecord @MockAccountPubSub
Scenario: Successfully creating a new business account with valid details supplied
	Given that that the endpoint request has been made with valid details for a business account
		| CompanyName | Email              | Password | FirstName | LastName |
		| Tech Corp   | tech.corp@test.com | P@55w0rd | Jane      | Smith    |
	When the request is posted to the account creation endpoint
	Then the response should indicate success with a 202 Accepted
	And the response body should contain the new Account ID
	And the response body should contain a URI to the accounts status endpoint

