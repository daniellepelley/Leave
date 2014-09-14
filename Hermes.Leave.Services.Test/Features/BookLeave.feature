Feature: BookLeave
	In order to manage my leave
	As an emplyee
	I want to be able to view my current leave allowance
	And be able to book leave

@mytag
Scenario Outline: View Leave Card
	Given the leave policy is for <allowance> hours per year
	And the leave policy is for <hour per day> hours per day
	And I have <days booked> days booked leave
	When I request a leave card
	Then the leave card should show <allowance> hours allowance
	And the leave card should show <lc taken> hours taken
	And the leave card should show <lc remaining> hours remaining

Scenarios:
    | allowance | hour per day | days booked | lc taken | lc remaining |
    | 200       | 8            | 4           | 32       | 168          |
    | 100       | 9            | 13          | 117      | -17          |
    | 150       | 8            | 0           | 0        | 150          |