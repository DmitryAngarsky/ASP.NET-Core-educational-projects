using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Platform
{
    public class Population
    {
        public static async Task Endpoint(HttpContext context)
        {
            string city = context.Request.RouteValues["city"] as string;

            int? pop = city?.ToLower() switch
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
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}