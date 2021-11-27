# BookCartAPI
## How to Run Locally ##
This API uses JWT bearer token authentication.
Bearer token can be get from end point  "/api/Authentication/GetJWTBearerToken"
Expiry of token is 24 hours.
Request for getting bearer token 

{
  "userName": "admin",
  "password": "admin"
}

For Running other APIs
You have to pass the bearer token in the requst header with field "Authorization" and value "Bearer {Token}"
