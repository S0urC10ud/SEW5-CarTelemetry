# SEW5-CarTelemetry
A small school-based project with ASP.net Core to model telemetry data for cars and access them via a REST-API. CRUD-Razor Page Scaffholds are used to display and modify the active state of used Local-DB.

I created this repository to help out my class mates as some are struggling a little bit with ASP.net.

Alternatively, you can override the "connectionString" in the appsettings.json File to use a diffrent relational Database. 

The access is modelled with a 1:n 3NF relationship using the Entity Framework. Furthermore, the NuGet-Package EntityFrameworkCore.Triggers is used to set the ModifiedAt and the CreatedAt timestamps.

## REST-API Documentation
The default path for the API is **/api/cars**.

For most request methods, an id can be specified as the most specific path of the route: **/api/cars/id**

### GET
Example: GET http://localhost:51648/api/cars
```json
[
    {
        "carId": 2,
        "name": "Hallo Welt2",
        "typ": 0,
        "telemetryData": [],
        "createdAt": "2020-10-16T11:02:09.2220521",
        "modifiedAt": "2020-10-16T11:02:09.2220521"
    }
]
```

Example: GET http://localhost:51648/api/cars/2
```json
{
    "carId": 2,
    "name": "Hallo Welt2",
    "typ": 0,
    "telemetryData": [],
    "createdAt": "2020-10-16T11:02:09.2220521",
    "modifiedAt": "2020-10-16T11:02:09.2220521"
}
```

### POST
Example: POST http://localhost:51648/api/cars/

Request Body:
```json
{
    "name": "SomeRandomCar",
    "typ": 0,
    "telemetryData": []
}
```
Response: 
```json
{
    "carId": 3,
    "name": "SomeRandomCar",
    "typ": 0,
    "telemetryData": [],
    "createdAt": "2020-10-23T11:39:08.8043839+02:00",
    "modifiedAt": "2020-10-23T11:39:08.8043839+02:00"
}
```

### PUT
Example: http://localhost:51648/api/cars/3
Request: 
```json
{
    "name": "SomeRandomCar2",
    "typ": 0,
    "telemetryData": []
}
```


### DELETE
Example: http://localhost:51648/api/cars/3

Response: 
```json
{
    "carId": 3,
    "name": "SomeRandomCar2",
    "typ": 0,
    "telemetryData": [],
    "createdAt": "2020-10-23T11:39:08.8043839",
    "modifiedAt": "2020-10-23T11:47:04.1889731"
}
```


## Demo Images
The index page:<br/>
<kbd align="center">
<img src="https://github.com/S0urC10ud/SEW5-CarTelemetry/blob/master/demoImages/index.png" width="50%"/>
</kbd>
Create a car:<br/>
<kbd align="center">
<img src="https://github.com/S0urC10ud/SEW5-CarTelemetry/blob/master/demoImages/createCar.png" width="50%"/>
</kbd>
View the details of a car:<br/>
<kbd align="center">
<img src="https://github.com/S0urC10ud/SEW5-CarTelemetry/blob/master/demoImages/carDetails.png" width="50%"/>
</kbd>
Show telemetry data:<br/>
<kbd align="center">
<img src="https://github.com/S0urC10ud/SEW5-CarTelemetry/blob/master/demoImages/showTelemetry.png" width="50%"/>
</kbd>

## Getting started
Open the project in visual studio and type "Update-Database" in the PackageManager-Console.
