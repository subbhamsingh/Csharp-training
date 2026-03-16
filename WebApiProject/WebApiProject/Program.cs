
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Middleware;
using WebApiProject.Repositories;
using WebApiProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
builder.Services.AddScoped<IBorrowRecordService, BorrowRecordService>();

//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add<LogFilter>();
//});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("dbcs")
    ));

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Library API";
    config.Version = "v1";
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();

