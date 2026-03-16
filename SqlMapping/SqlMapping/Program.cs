
using Microsoft.EntityFrameworkCore;
using SqlMapping.Logic;
using SqlMapping.Models;


var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddScoped<UserLogic>();

builder.Services.AddDbContext<ProjectJoinContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "SQL API";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();