
Feature: PriorityToDoList
	Help keep note of tasks that needs to be completed 
	Arrange by priority
	Mark when tasks are done 
	Keep track of the amount of completed tasks
	Keep track of the amount of uncomplete tasks 

Scenario: Make sure the page loads correctly
	Given I am on the priority to do list screen 
	Then the title should be Priority To-Do List

Scenario: Make sure the pages loads with all parts 
	Given I am on the priority to do list screen 
	Then the text area is displayed
	Then the high button is displayed 
	Then the medium button is displayed
	Then the low button is displayed
	Then the clear text button is displayed
	Then the high priority table is displayed
	Then the medium priority table is displayed
	Then the low priority table is displayed
	Then the reset button is displayed

Scenario: Clear text from the text area 
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
	When I select the clear text button
	Then the text area shoud be empty 

Scenario: Add task to High Priority 
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
	When I select the high button
	Then the task should appear in the high priority table

Scenario: Add task to High Priority and complete task
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the high button 
	When I select the done button in the high table
	Then the high priority task should appear in the complete table

Scenario: Add task to High Priority and remove it
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the high button 
	When I select the remove button from the high priority table 
	Then the task should be removed from the high table

Scenario: Add no text to a High Priority table 
	Given I am on the priority to do list screen 
		And I enter a tasks of 
	When I select the high button
	Then An alert box should be displayed with the message No text in input field. Please add text before adding the task.

Scenario: Add the same task twice to the High Priority Table
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the high button 
		And I enter a tasks of write code
	When I select the high button
	Then An alert box should be displayed with the message That priority list already contains that task.

Scenario: Add task to High Priority and incomplete increases 
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
	When I select the high button
	Then incomplete increases by 1 

Scenario: Add task to High Priority and complete task and increase completed tasks by 1
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the high button 
	When I select the done button in the high table
	Then complete increases by 1 

Scenario: Add task to Medium Priority 
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
	When I select the med button 
	Then the task should appear in the medium priority table

Scenario: Add task to Medium Priority and complete task
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the med button 
	When I select the done button in the medium table
	Then the medium priority task should appear in the complete table 

Scenario: Add task to Medium Priority and remove it
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the med button 
	When I select the remove button from the medium priority table 
	Then the task should be removed from the medium table

Scenario: Add no text to a Medium Priority table 
	Given I am on the priority to do list screen 
		And I enter a tasks of 
	When I select the med button
	Then An alert box should be displayed with the message No text in input field. Please add text before adding the task.

Scenario: Add the same task twice to the Medium Priority Table
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the med button 
		And I enter a tasks of write code
	When I select the med button 
	Then An alert box should be displayed with the message That priority list already contains that task.

Scenario: Add task to Medium Priority and incomplete increases 
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
	When I select the med button
	Then incomplete increases by 1 

Scenario: Add task to Medium Priority and complete task and increase completed tasks by 1
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the med button 
	When I select the done button in the medium table
	Then complete increases by 1 

Scenario: Add task to Low Priority 
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
	When I select the low button
	Then the task should appear in the low priority table

Scenario: Add task to Low Priority and complete task
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the low button 
	When I select the done button in the low table
	Then the low priority task should appear in the complete table 

Scenario: Add task to Low Priority and remove it
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the low button 
	When I select the remove button from the low priority table 
	Then the task should be removed from the low table

Scenario: Add no text to a Low Priority table 
	Given I am on the priority to do list screen 
		And I enter a tasks of 
	When I select the low button
	Then An alert box should be displayed with the message No text in input field. Please add text before adding the task.

Scenario: Add the same task twice to the Low Priority Table
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the low button 
		And I enter a tasks of write code
	When I select the low button
	Then An alert box should be displayed with the message That priority list already contains that task.

Scenario: Add task to Low Priority and incomplete increases 
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
	When I select the low button
	Then incomplete increases by 1 

Scenario: Add task to Low Priority and complete task and increase completed tasks by 1
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the low button 
	When I select the done button in the low table
	Then complete increases by 1 

Scenario: Adding tasks to all priority to do lists and then clearing values
	Given I am on the priority to do list screen 
		And I enter a tasks of write code
		And I select the low button
		And I enter a tasks of write code
		And I select the med button
		And I enter a tasks of write code
		And I select the high button
	When I click the reset Button
	Then the task should be removed from the low table 
	Then the task should be removed from the medium table
	Then the task should be removed from the high table