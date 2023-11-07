using Microsoft.AspNetCore.Routing;

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

        }
    }
}
