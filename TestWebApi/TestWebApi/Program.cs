
using System.Text.Json.Serialization;
using TestWebApi.Middleware;
using TestWebApi.Repositories;
using TestWebApi.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSingleton<IEmployeeTaskRepository, EmployeeTaskRepository>();
builder.Services.AddSingleton<IEmployeeTaskService, EmployeeTaskService>();

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Employee Task API";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();  
    app.UseSwaggerUi();
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();

