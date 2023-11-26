using Application.Users.Commands;
using Application.Users.Queries;
using Domain.Users;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Presentation.RequestModels.Users;

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
            app.MapPut(basePattern + "/{userId}", UpdateUser);
        }

        public void DefineServices(IServiceCollection services)
        {

        }

        public async Task<IResult> CreateUser(ISender sender, [FromBody] CreateUserRequestCommand request)
        {
            var result = await sender.Send(request);
            if(result.IsSuccess)
            {
                return Results.Ok();
            }
            else
            {
                return Results.BadRequest(result.Error);
            }
        }
        public async Task<IResult> UpdateUser(HttpContext context, ISender sender, [FromRoute] Guid userId, [FromBody] UpdateUserRequest request)
        {
            //var updatedBy = context.User.Identity.Name;
            var updatedBy = "ryanlintag@gmail.com";
            var updateCommand = new UpdateUserRequestCommand(userId, request.email, request.firstName, request.lastName, request.middleName, request.role, request.isActive, updatedBy);
            var result = await sender.Send(updateCommand);
            if(result.IsSuccess)
            {
                return Results.Ok();
            }
            else 
            {
                return Results.BadRequest(result.Error);
            }
        }
    }
}
