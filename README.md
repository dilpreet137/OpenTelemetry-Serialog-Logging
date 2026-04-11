Phoenix (CoreAPI)
==================

Short project summary
---------------------
A small ASP.NET Core Web API implemented with .NET 10. The repository contains a single API project that demonstrates the minimal Web API setup, configuration, and a sample controller (`WeatherForecastController`) used to show routing, configuration and DTO usage.

What is implemented
--------------------
- `CoreAPI/Phoenix.CoreAPI` ASP.NET Core Web API targeting .NET 10.
- Minimal hosting using `Program.cs` and `WebAppServiceConfiguration.cs` for service registration.
- Configuration files: `appsettings.json` and `appsettings.Development.json`.
- Sample data/DTO: `WeatherForecast.cs`.
- Sample controller: `Controllers/WeatherForecastController.cs` exposing a simple GET endpoint.

Project structure (important files)
-----------------------------------
- `CoreAPI/Phoenix.CoreAPI/Phoenix.CoreAPI.csproj` - project file
- `CoreAPI/Phoenix.CoreAPI/Program.cs` - app entry and host configuration
- `CoreAPI/Phoenix.CoreAPI/WebAppServiceConfiguration.cs` - extension-style service registration
- `CoreAPI/Phoenix.CoreAPI/Controllers/WeatherForecastController.cs` - example API controller
- `CoreAPI/Phoenix.CoreAPI/WeatherForecast.cs` - sample model/DTO
- `CoreAPI/Phoenix.CoreAPI/appsettings*.json` - configuration

How to run
----------
Using the .NET CLI (from repository root):

1. Change directory:

   `cd CoreAPI/Phoenix.CoreAPI`

1.5 (Optional) Update environment variables for OpenTelemetry:

   If you use OpenTelemetry for tracing/metrics, set the required environment variables before running the app. Example (PowerShell):

   `$env:OTEL_EXPORTER_OTLP_ENDPOINT = "URL_TO_OTLP"`

   `$env:OTEL_EXPORTER_OTLP_HEADERS = "YOUR_HEADERS"`

2. Run the API:

   `dotnet run`

Or open the solution in Visual Studio 2026 and run the `Phoenix.CoreAPI` project (use the `Development` launch profile if desired).

Available endpoint
------------------
- GET `/WeatherForecast` - returns the sample weather forecast payload used to validate routing and serialization.

Notes for interviews
--------------------
Use this project to discuss:
- Minimal ASP.NET Core hosting model and `Program.cs` composition.
- Dependency injection and where services are registered (`WebAppServiceConfiguration`).
- Configuration and environment-specific settings (`appsettings.json`, `appsettings.Development.json`).
- How controllers and DTOs are structured and tested manually via the included endpoint.

Repository
----------
Remote origin: `https://github.com/dilpreet137/Phoenix`

License & contribution
----------------------
This repository follows standard GitHub workflow. Open issues and pull requests are welcome.
