Feature: Register user
Register a user at Shoptester

    Scenario: Open register form
        Given I am at the shoptester homepage
        And  I see the register button
        When I am click on the registre button
        Then I should see the register form