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
