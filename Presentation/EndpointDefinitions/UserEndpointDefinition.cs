using Application.Users.Queries;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Authorization;

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
        }

        public void DefineServices(IServiceCollection services)
        {

        }

    }
}
