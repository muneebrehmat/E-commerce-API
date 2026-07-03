namespace ECommerceProject.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("========== Request ==========");
            Console.WriteLine($"Method : {context.Request.Method}");
            Console.WriteLine($"Path   : {context.Request.Path}");
            Console.WriteLine($"Time   : {DateTime.Now}");

            await _next(context);

            Console.WriteLine("========== Response ==========");
            Console.WriteLine($"Status Code : {context.Response.StatusCode}");
            Console.WriteLine();
        }
    }
}
