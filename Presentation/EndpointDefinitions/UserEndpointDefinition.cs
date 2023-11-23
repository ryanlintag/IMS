using Application.Users.Commands;
using Application.Users.Queries;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.EndpointDefinitions
{
    public sealed class UserEndpointDefinition : IEndpointDefinition
    {
        private readonly string basePattern = "/users";
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet(basePattern, async (ISender sender) =>
            {
                var q = new GetUsersQuery("", 1, 1, "", "");
                var res = await sender.Send(q);
                return res;
            });

            app.MapPost(basePattern, CreateUser);
        }

        public void DefineServices(IServiceCollection services)
        {

        }

        public async Task<IResult> CreateUser(ISender sender, [FromBody] CreateUserRequestCommand request)
        {
            var result = await sender.Send(request);
            return Results.Ok();
        }

}
}
