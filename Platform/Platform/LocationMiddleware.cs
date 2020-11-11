using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Platform
{
    public class LocationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MessageOptions _messageOptions;

        public LocationMiddleware(RequestDelegate next, IOptions<MessageOptions> messageOptions)
        {
            _next = next;
            _messageOptions = messageOptions.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location")
                await context.Response
                    .WriteAsync($"{_messageOptions.CityName}, {_messageOptions.CountryName}");
            else
                await _next(context);
        }
    }
}