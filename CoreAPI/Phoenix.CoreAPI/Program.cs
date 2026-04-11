using Serilog;
using System.Globalization;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
    .Enrich.FromLogContext()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting Core API");

    var builder = WebApplication.CreateBuilder(args);
    var isDevEnvironment = builder.Environment.IsDevelopment();

    builder.Services.AddControllers();
    builder.Services.AddOpenApi();

    var app = builder.Build();

    if (isDevEnvironment)
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (HostAbortedException hostAbortedExeption)
{
    if (Assembly.GetEntryAssembly()?.GetName().Name != "ef")
    {
        Log.Fatal(hostAbortedExeption, "Application terminated unexpectedly");
    }
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
