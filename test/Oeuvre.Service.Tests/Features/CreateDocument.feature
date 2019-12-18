Feature: CreateDocument
	
	Creating a new document

@document
Scenario: Creating a new text document
	Given user creates a new document
	And changes the title to "My First Document"
	And changes the content to "A simple content"
	When presses the save button
	Then a new document should be stored
	