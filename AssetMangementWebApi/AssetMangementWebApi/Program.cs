

using AssetMangementWebApi.Middleware;
using AssetMangementWebApi.Services;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddSingleton<AssetService>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   

    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// custom middleware added 
app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();



app.Run();
