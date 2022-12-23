Feature: Posting
	User posts messages

@mytag
Scenario: Post message
	Given In our Social Network
	When The user writes a <PostMessage>
	And The user writes the <UserName> 
	Then The last <Post> is displayed
	
Examples: 
	| PostMessage             | UserName | Post           				 |
	| Alice -> I love Python! | Alice    | I love Python! (1 second ago) |