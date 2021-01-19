using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Platform
{
    public class Population
    {
        private readonly RequestDelegate _next;

        public Population()
        {
            
        }

        public Population(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string[] parts = context.Request.Path.ToString()
                .Split("/", StringSplitOptions.RemoveEmptyEntries);
            
            if (parts.Length == 2 && parts[0] == "population")
            {
                string city = parts[1];

                int? pop = city.ToLower() switch
                {
                    "london" => 8_136_000,
                    "paris" => 2_141_000,
                    "monaco" => 39_000,
                    _ => null
                };

                if (pop.HasValue)
                {
                    await context.Response
                        .WriteAsync($"City: {city}, Population: {pop}");
                    return;
                }
            }

            if (_next != null)
                await _next(context);
        }
    }
}