using goapp.application.useCase.users.createUser;
using goapp.application.UseCase.Users.LoginUser;
using goapp.webApi.HttpResult;
using MediatR;

namespace goapp.webApi.Router
{
    public static class UserRouter
    {
        const string PATH = "/User";
        
        public static IEndpointRouteBuilder MapUser(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(PATH, async (IMediator mediator, CreateUserRequest request)
                => await mediator.Send(request).ToHttpResult());

            return endpoint;
        }
    }
}
