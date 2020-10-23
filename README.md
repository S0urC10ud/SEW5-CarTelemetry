# SEW5-CarTelemetry
A small school-based project with ASP .net Core to model telemetry data for cars. CRUD-Razor Page Scaffholds are used to display and modify the active state of used Local-DB.

I created this repository to help out my class mates as some are struggling a little bit with ASP.net.

Alternatively, you can override the "connectionString" in the appsettings.json File to use a diffrent relational Database. 

The access is modelled with a 1:n 3NF relationship using the Entity Framework. Furthermore, the NuGet-Package EntityFrameworkCore.Triggers is used to set the ModifiedAt and the CreatedAt timestamps.

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
