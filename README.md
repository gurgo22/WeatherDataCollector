# Weather Data Collector

Weather Data Collector is a console application that demonstrates **Dependency Injection (DI)**
by retrieving weather data from multiple sources and storing it in a database.
The project is designed to show how different data sources can be integrated seamlessly using DI principles.

---

## Features

### Multiple Data Sources
- **API Source**: Retrieves real-time weather data from an external weather API called OpenWeatherAPI.
- **XML File Source**: Reads weather data from a local XML file.

### Dependency Injection
- Uses DI to swap between different data sources.
- Makes it easier to extend and maintain code.

### Database Integration
- Stores retrieved weather data in a **Microsoft SQL Server** database using **EF**.
- Database oeprations are handled with a dedicated service class.

### Data Handling
- Parses JSON responses from the API.
- Reads and extracts weather data from XML files.

---

## Technology Stack

- **C# with .NET** – Core programming language.
- **Entity Framework Core** – ORM for database.
- **Microsoft SQL Server** – Database management system.
