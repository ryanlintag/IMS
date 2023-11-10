using Application.Users.Queries;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Presentation.Authorization;

namespace Presentation.Modules
{
    public sealed class UserModule : ApiModule
    {
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
            }).AddEndpointFilter<ApiKeyEndpointFilter>();
        }
    }
}
