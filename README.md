# BookCartAPI
## How to Run Locally ##
This API uses JWT bearer token authentication.
Bearer token can be get from end point  "/api/v1/Authentication/GetJWTBearerToken". 
Expiry of token is 24 hours. 
Request for getting bearer token 

{
  "userName": "admin",
  "password": "admin"
}

## Version ##
This API is version 1. When you use swagger give version as "1"

## For Running other APIs ##

You have to pass the bearer token in the requst header with field "Authorization" and value "Bearer {Token}"
 or 
You can use Authorization Type as "Bearer Token" in Postman.

## Environments ##
This API has 2 environments (Development & Production). You can select the required environment from launchSettings.json file.
