
Feature: Tests
	
Scenario: GET_Verify list of users
	Given that reqres service is started with GET endpoint /api/users?page=2
	Then the StatusCode is equal to OK
	And the ResponseDescription is equal to OK
	And the list of users are returned as below
	| id | first_name | last_name | avatar                                                              |
	| 4  | Eve        | Holt      | https://s3.amazonaws.com/uifaces/faces/twitter/marcoramires/128.jpg |
	| 5  | Charles    | Morris    | https://s3.amazonaws.com/uifaces/faces/twitter/stephenmoon/128.jpg  |
	| 6  | Tracey     | Ramos     | https://s3.amazonaws.com/uifaces/faces/twitter/bigmancho/128.jpg    |

@ignore
Scenario: GET_Verify list of a user
	Given that reqres service is started with GET endpoint /api/users/2
	Then the StatusCode is equal to OK
	And the ResponseDescription is equal to OK
	And the user record is as below
	| id | first_name | last_name | avatar                                                             |
	| 2  | Janet      | Weaver    | https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg |
	
Scenario: POST_Verify that a user record can be posted
	Given that reqres service is started with POST endpoint /api/users
	Then the status code for Post is equal to Completed
	And the response status for Post is equal to Created

Scenario: PUT_Verify that a user record can be updated
	Given that reqres service is started with PUT endpoint /api/users/2
	Then the status code for Put is equal to Completed
	And the response status for Put is equal to OK

Scenario: DELETE_Verify that a user record can be deleted
	Given that reqres service is started with DELETE endpoint /api/users/2
	Then the status code for Delete is equal to NoContent
	And the response status for Delete is equal to No Content