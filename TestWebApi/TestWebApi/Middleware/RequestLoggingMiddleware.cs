namespace TestWebApi.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            var startTime = DateTime.Now;
            Console.WriteLine("Custom Middleware before");
            Console.WriteLine($"Request Path: {context.Request.Path}");
            Console.WriteLine($"Start Time: {startTime}");

            await _next(context);

            var endTime = DateTime.Now;
            var duration = endTime - startTime;

            Console.WriteLine($"End Time: {endTime}");
            Console.WriteLine($"Duration: {duration.TotalMilliseconds} ms");
            Console.WriteLine("Custom Middleware after");

        }
    }
}
