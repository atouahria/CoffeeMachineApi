# CoffeeMachineApi
Coffee Machine API written in ASP.NET Core and .NET 8.0.

# Project structure
  - Domain Layer: Contains basic entities.
  - Application Layer: Contains business logic, use cases, DTOs, Mappings and Helpers.
  - Infrastructure Layer: Contains specific implementation of the BeverageRepository.
  - Presentation Layer: Contains the API controllers and application configuration.

# Information
This is just a simple in-memory repository for the sake of the exercise and to avoid the need of a database connection and setup.
All of this can be replaced by a database by implementing the IBeverageRepository interface and using Entity Framework Core (or any other ORM)
by creating a class AppDbContext that inherits from DbContext and inject it in this class. Then it will used to retrieve data about beverages and their ingredients.

# Tests
Unit tests wera added for CoffeeMachine.Infrastructure and CoffeeMachineApi projects.
        
