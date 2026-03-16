using Microsoft.Win32;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using static System.Net.WebRequestMethods;

namespace WebApiProject.Middleware
{
    public class RequestLoggingMiddleware
    {

        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Logging Middleware BEFORE");
            Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"Response Status: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path}");
            Console.WriteLine("Logging Middleware AFTER");
        }
    


    }
}
