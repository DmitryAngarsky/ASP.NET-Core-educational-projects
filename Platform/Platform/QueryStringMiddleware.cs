using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Platform
{
    public class QueryStringMiddleware
    {
        private readonly RequestDelegate _next;

        public QueryStringMiddleware()
        {
        }

        public QueryStringMiddleware(RequestDelegate nextDelegate)
        {
            _next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get
                && context.Request.Query["custom"] == "true")
            {
                await context.Response.WriteAsync("Class-Based Middleware\n");
            }

            if (_next != null)
            {
                await _next(context);
            }
        }
    }
}