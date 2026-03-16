
using System.Net;
using System.Text.Json;
using WebApiProject.Exceptions;

namespace WebApiProject.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                Console.WriteLine("Exception Middleware BEFORE");
                await _next(context);
                Console.WriteLine("Exception Middleware AFTER");
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

               
                context.Response.StatusCode = ex switch
                {
                    NotFoundException => (int)HttpStatusCode.NotFound, 
                    BookAlreadyBorrowedException => (int)HttpStatusCode.Conflict,  
                    _ => (int)HttpStatusCode.InternalServerError   
                };

                var response = new
                {
                    message = ex.Message,
                    status = context.Response.StatusCode
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
