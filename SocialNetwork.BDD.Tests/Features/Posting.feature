Feature: Posting
	User posts messages

@mytag
Scenario: Post message
	Given The user is <Alice>
	And Uses the -> command
	When It types a <Hello bob!> message
	Then A post is added to <Alice> timeline