# DotNetLabs 
### by Nestor Rojas
### Components
1.Entity : A reverse engineer process have created entity classes and a derived context based on the schema of the existing database. The entity classes are simple C# objects that represent the data you will be querying and saving.
 - The context represents a session with the database and allows you to query and save instances of the entity classes.
 - Dependency Injection is central to ASP.NET Core. Services (such as DbContext) are registered with dependency injection during application startup. Components that require these services (such as your MVC controllers) are then provided these services via constructor parameters or properties.
 
2.Repository Design Pattern: One of the most widely used design patterns. It will persist objects without the need of having to know how those objects would be actually persisted in the underlying database, i.e., without having to be bothered about how the data persistence happens underneath. The knowledge of this persistence, i.e., the persistence logic, is encapsulated inside the Repository.

3.Web API : connected to the Repository will perform all the data persistence required by the client

4. Web App : Web Client consuming the API

# ASP.NET Core .NET 7 API

This repository contains an ASP.NET Core API built on .NET 7. It serves as a starting point for building robust and scalable web APIs using the latest version of the ASP.NET Core framework. 

## Features

- Built on the latest .NET 7, taking advantage of the new features and performance improvements.
- Utilizes the MVC architectural pattern for organizing and structuring the codebase.
- Implements a RESTful API design, adhering to best practices and standards.
- Comes with built-in support for Swagger UI, allowing easy API documentation and testing.
- Utilizes Entity Framework Core as an ORM for data access.
- Follows a modular structure, making it easy to add, remove, or extend functionality.
- Supports dependency injection, enabling loose coupling and testability.
- Includes sample controllers, models, and data access layers to get started quickly.

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) or later.
- [Visual Studio](https://visualstudio.microsoft.com/) or any other compatible code editor.

## Getting Started

To get started with this API, follow these steps:

1. Clone the repository: git clone https://github.com/nestorojas/DotNetLabs.git

2. Open the solution file `YourSolution.sln` in Visual Studio.

3. Build the solution to restore NuGet packages and compile the project.

4. Set the `YourProjectName.Web` as the startup project.

5. Configure the database connection string in the `appsettings.json` file.

6. Apply any pending database migrations: dotnet ef database update

7. Run the application:dotnet run

8. Access the API in your web browser or using an API testing tool at `https://localhost:<port>/`.

## API Documentation

This API comes with Swagger UI integration to facilitate easy documentation and testing of the endpoints. To access the API documentation, follow these steps:

1. Run the application as described in the "Getting Started" section.

2. Open your web browser and navigate to `https://localhost:<port>/swagger`.

3. Explore the available endpoints, request/response models, and try out the API operations.

## Customization and Extension

This API is designed to be easily customizable and extensible. Here are some suggestions on how you can extend the functionality:

- Add new controllers to handle additional resources or business logic.
- Create new models and data access layers to integrate with your database or external services.
- Customize the API routing and add route attributes to controllers and actions.
- Implement authentication and authorization mechanisms based on your requirements.
- Integrate with third-party libraries or services by adding new services and dependencies.
- Extend or modify the existing database schema using Entity Framework Core migrations.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please open an issue or submit a pull request. Make sure to follow the existing code style and adhere to the project's guidelines.

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use and modify the code as per the license terms.



