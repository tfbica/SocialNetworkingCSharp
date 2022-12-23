Feature: Posting
	User posts messages

@mytag
Scenario: Post message
	Given In our Social Network
	When The user writes a <PostMessage>
	And <Seconds> has passed since the post
	And The user writes the <UserName>
	Then The last <Post> is displayed
	
Examples: 
	| PostMessage             | Seconds | UserName | Post                          |
	| Alice -> I love Python! | 1       | Alice    | I love Python! (1 second ago) |