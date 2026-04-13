using Phoenix.CoreAPI;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var isDevEnvironment = builder.Environment.IsDevelopment();

builder.ConfigureLogging();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (isDevEnvironment)
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openapi/v1.json", "Phoenix.CoreAPI v1"));
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
