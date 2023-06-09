# Bingo's Lonely Animal House API

### By Emma Gerigscott

## Table of Contents
1. [Project Description](#description)
2. [Technologies Used](#technologies-used)
3. [Database Setup Instructions](#database-setup-instructions)
4. [Using This API](#using-this-api)
5. [How To Query This API](#query-parameters-for-a-get-request-on-animals)
6. [Bugs](#known-bugs)
7. [License](#mit-license)

## Description

An API to search, add, edit, and delete the animals at Bingo's Lonely Animal House. This API generates a JWT Token: edit, add, and delete methods are only authorized for "Admin" role.

## Technologies Used

* C#
* .NET
* ASP.NET Core
  * Authentication
  * Versioning
* API
* Entity Framework Core
* Pomelo Entity Framework Core
* EFCore Migrations
* Swashbuckle
* Swagger
* MySQL

## Database Setup Instructions

1. Clone this repo.
2. Open your terminal (e.g. Terminal or GitBash) and navigate to this project's directory called "AnimalShelterApi".
3. Set up the project:
  * Create a file called 'appsettings.json' in AnimalShelterApi.Solution/AnimalShelterApi directory
  * Add the following code to the appsettings.json file:
  ```
  {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=travel_api;uid=[YOUR_SQL_USER_ID];pwd=[YOUR_SQL_PASSWORD];"
    }
  }
  ```
  * Make sure to plug in your SQL user id and password at ```[YOUR_SQL_USER_ID]``` and ```[YOUR_SQL_PASSWORD]```
4. Set up the database:
  * Make sure EF Core Migrations is installed on your computer by running ```dotnet tool install --global dotnet-ef --version 6.0.0```
  * In the production folder of the project (AnimalShelterApi.Solution/AnimalShelterApi) run:
  ```
  dotnet ef database update
  ```
  * You should see the new schema in your _Navigator > Schemas_ tab of your MySql Workbench on refresh called ```animalshelter_api```

## Using This API
* Endpoints for **v1.0** API are as follows:
```
GET https://localhost:5001/api/v1/animals/
POST https://localhost:5001/api/v1/animals/
PUT https://localhost:5001/api/v1/animals/{id}
DELETE https://localhost:5001/api/v1/animals/{id}
```

* Additional endpoints for **v1.1**:
```
GET https://localhost:5001/api/v1.1/animals/{id}
PATCH https://localhost:5001/api/v1.1/animals/{id}
```
  * To use the PATCH, use the following sample JSON syntax:
  ```
  [
    { "op": "replace", "path": "/Available", "value": false }
  ]
  ```
  * "op" is the operation, "path" is the table column name, and "value" is the new value.
* In your terminal run ```dotnet watch run``` in the project directory.
* In your browser open https://localhost:5001/swagger/index.html
* Use the GUI to navigate the API

## Query Parameters for a GET Request on **Animals**: 

| Parameter  | Type   | Required     | Description                                      | Sample Url  |
|----------- |-----   | ---------    | -------------                                    | ----------  |
| Animals | List | not required | Returns a list of all animals in database | https://localhost:5001/api/animals |
| Name       | String | not required | Returns animals with a matching name value     | https://localhost:5001/api/animals?name={ANIMAL_NAME} |
| Type   | String | not required | Returns animals with a matching type value (i.e. 'Dog' or 'Cat') | https://localhost:5001/api/animals?type={ANIMAL_TYPE} |
| Breed    | String | not required | Returns animals with a matching breed value  | https://localhost:5001/api/animals?breed={BREED} |
| Date | DateTime(YYYY-mm-DD)    | not required | Returns animals with a matching admittance date (note: must include Year, Month, and Day) | https://localhost:5001/api/animals?date={YYYY-mm-DD} |
| Available | bool | not required | Returns list of animals that are available (true) or adopted (false) | https://localhost:5001/api/animals?available={true/false} |
| Random | bool | not required | Returns a random animal, Default is False | https://localhost:5001/api/animals?random={TRUE} |


## Known Bugs

* _Random query may return null animal as it counts the list of animals to retrieve random id number._

## [MIT](https://opensource.org/license/mit/) License 

Copyright © 2023 Emma Gerigscott