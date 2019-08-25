Solutions is includes following projects:

DataTier Project .NET Core 2.1
 - Repository pattern
 - Includes IUserRepository and MockUserRepository for in memory-data.
 - We can easily create a SQL repo to retrieve data from SQL using Entity Framework (for example) or ADO.NET
 - IUserRepository Interface allows us to inject the interface where needed and mock repo in Unit Tests

Model Project .NET Core 2.1
 - Stores Models
 - ModelId abstract class provides resuable properties (like "Id") that can can be inherited/resused on multiple models

WebServices Project .NET Core 2.1
 - Hosts API over: http://localhost:58829
 - http://localhost:58829/api/user

ConsoleApp Project .NET Core 2.1
 - Client app used to call services

WebSite Project .NET Core 2.1, Angular 5
 - Client app using Angular to call services

MSTest Project .NET Core 2.1
 - Unit tests to retrieve all Users and user with same Id

Solution start up projects: WebServices and ConsoleApp

Angular WebSite can be started using:
ng serve
http://localhost:4200/

Misc:
WebServices and WebSite are configured to resolve CORS issue when running locally.