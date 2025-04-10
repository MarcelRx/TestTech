Feature: Login user
Login a user at Shoptester

    Scenario: Open register form
        Given I am on the login page
        When I enter "admin1" as the email
        When I enter "a" as the password
        When I click on the sign in button
        Then I should be logged in