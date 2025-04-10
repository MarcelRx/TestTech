Feature: Register user
Register a user at formbridge

    Scenario: Open register form
        Given I am at the formbridge homepage
        And  I see the login button
        When I am click on the login button
        Then I should see the login page