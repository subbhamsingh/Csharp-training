
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//builder.Services.AddAuthentication("Basic")
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("Basic", null);

builder.Services.AddAuthentication("DemoScheme")
    .AddCookie("DemoScheme");

builder.Services.AddAuthorization();



//builder.Services.AddOpenApiDocument(config =>
//{
//    config.Title = "Middleware";
//    config.Version = "v1";
//});


// authentication, authorization
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Middleware";
    config.Version = "v1";

    config.AddSecurity("cookieAuth", new NSwag.OpenApiSecurityScheme
    {
        Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
        Name = ".AspNetCore.Cookies",
        In = NSwag.OpenApiSecurityApiKeyLocation.Cookie,
        Description = "Cookie Authentication"
    });

    config.OperationProcessors.Add(
        new NSwag.Generation.Processors.Security.AspNetCoreOperationSecurityScopeProcessor("cookieAuth"));
});

// hsts

//builder.Services.AddHsts(options =>
//{
//    options.MaxAge = TimeSpan.FromDays(365);   // 1 year
//    options.IncludeSubDomains = true;
//    options.Preload = true;
//});

//builder.Services.AddHsts(options =>
//{
//    options.MaxAge = TimeSpan.FromMinutes(1);
//});
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        policy =>
//        {
//            policy.AllowAnyOrigin()
//                  .AllowAnyMethod()
//                  .AllowAnyHeader();
//        });
//});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        policy => policy.WithOrigins("http://fake-domain-test.com"));
//});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowTestOrigin",
//        policy =>
//        {
//            policy.WithOrigins("http://fake-domain-test.com")
//                  .AllowAnyMethod()
//                  .AllowAnyHeader();
//        });
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTestOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseOpenApi();
    app.UseSwaggerUi();
}

//if (!app.Environment.IsDevelopment())
//{
//app.UseHsts();
//}


//app.UseHsts();
app.UseHttpsRedirection();

//app.UseCors("AllowAll");
app.UseCors("AllowTestOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
