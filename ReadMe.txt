Solutions is includes following projects:

DataTier Project:
 - Repository pattern
 - Includes IUserRepository and MockUserRepository for in memory-data.
 - We can easily create a SQL repo to retrieve data from SQL using Entity Framework (for example) or ADO.NET
 - IUserRepository Interface allows us to inject the interface where needed and mock repo in Unit Tests

Model Project:
 - Stores Models
 - ModelId abstract class provides resuable properties (like "Id") that can can be inherited/resused on multiple models

WebServices Project:
 - Hosts API over: http://localhost:58829
 - http://localhost:58829/api/user

ConsoleApp Prooject:
 - Client app used to call services

WebSite Project:
 - Client app using Angular to call services

Test Project:
 - Unit tests to retrieve all Users and user with same Id


Solution start up projects: WebServices and ConsoleApp

Angular WebSite can be started using:
ng serve
http://localhost:4200/

Misc:
WebServices and WebSite are configured to resolve CORS issue when running locally.
Projects are using .NET CORE 2.1
Angular 5