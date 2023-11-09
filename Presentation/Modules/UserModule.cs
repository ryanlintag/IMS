using Application.Users.Queries;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Modules
{
    public sealed class UserModule : ApiModule
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private const string baseEndpoint = "/users";
        public UserModule() : base(baseEndpoint)
        {
            //this.RequireAuthorization();
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(emptyPath, async (ISender sender) =>
            {
                var q = new GetUsersQuery("", 1, 1, "", "");
                var res = await sender.Send(q);
                return res;
                //var startDate = DateOnly.FromDateTime(DateTimeOffset.Now.Date);
                //return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                //{
                //    Date = startDate.AddDays(index),
                //    TemperatureC = Random.Shared.Next(-20, 55),
                //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                //}).ToArray());
            });
        }
    }
    //public class UserRecord
    //{
    //    public DateOnly Date { get; set; }

    //    public int TemperatureC { get; set; }

    //    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    //    public string? Summary { get; set; }
    //}
}
