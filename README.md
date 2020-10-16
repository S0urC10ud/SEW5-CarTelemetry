# SEW5-CarTelemetry
A small school-based project with ASP .net Core to model telemetry data for cars. CRUD-Razor Page Scaffholds are used to display and modify the active state of used Local-DB.

Alternatively, you can override the "connectionString" in the appsettings.json File to use a diffrent relational Database. 

The access is modelled with a 1:n 3NF relationship using the Entity Framework. Furthermore, the NuGet-Package EntityFrameworkCore.Triggers is used to set the ModifiedAt and the CreatedAt timestamps.


## Getting started
Open the project in visual studio and type "Update-Databae" in the PackageManager-Console.
