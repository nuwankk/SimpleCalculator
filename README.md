# SimpleCalculator
 Simple calculator backed by .NET 6 wrapped with OpenAPI 2.0

1. All the endpoints are encapsulated with the authorization header and an explicit method is available to create the required authorization token.

2. The default JWT token expiration is 20 minutes, and you are required to create a new token in the event it expires (for testing purposes, the token generation come with pre-defined username and password as below)
       a. username goes as "appadmin"
       b. password goes as today’s date in "MM/dd/yyyy" format

3. The Web API is integrated with OpenAPI 2.0 and simple executions can be tested with Swagger interfaces. For security reasons, the Swagger interface does not allow you to modify the authorization header, but you can use any rest client or browser extension to test the end points.
