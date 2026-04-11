using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using System.Globalization;

namespace Phoenix.CoreAPI;

internal static class WebApplicationBuilderConfiguration
{
    internal static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        var openTelemetryAttributes = new Dictionary<string, object>()
        {
            { "service.name", "Phoenix.CoreAPI" },
            { "service.version", "1.0.0" },
            { "service.instance.id", "service-instance-1" }
        };

        var logger = new LoggerConfiguration()
            .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
            .WriteTo.OpenTelemetry(opt =>
            {
                opt.ResourceAttributes = openTelemetryAttributes;
            })
            .CreateLogger();

        Log.Logger = logger;

        builder.Logging.AddSerilog(logger);
        builder.Services.AddSerilog(logger);

        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resourceBuilder =>
            {
                resourceBuilder
                    .AddService("Phoenix.CoreAPI")
                    .AddAttributes(openTelemetryAttributes);
            })
            .WithMetrics(metrics =>
            {
                metrics
                    .AddRuntimeInstrumentation()
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            })
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            })
            .UseOtlpExporter();
    }
}
