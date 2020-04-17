# ASP.NET Web APIs
## Contains a very simple architecture for a Web API built on top of SQL Server and C#
### Components
1.Entity : A reverse engineer process have created entity classes and a derived context based on the schema of the existing database. The entity classes are simple C# objects that represent the data you will be querying and saving.
 - The context represents a session with the database and allows you to query and save instances of the entity classes.
 - Dependency Injection is central to ASP.NET Core. Services (such as DbContext) are registered with dependency injection during application startup. Components that require these services (such as your MVC controllers) are then provided these services via constructor parameters or properties.
 
2.Repository Design Pattern: One of the most widely used design patterns. It will persist objects without the need of having to know how those objects would be actually persisted in the underlying database, i.e., without having to be bothered about how the data persistence happens underneath. The knowledge of this persistence, i.e., the persistence logic, is encapsulated inside the Repository.

3.Web API : connected to the Repository will perform all the data persistence required by the client
