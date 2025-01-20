using goapp.application.UseCase.Users.LoginUser;
using goapp.webApi.HttpResult;
using MediatR;

namespace goapp.webApi.Router
{
    public static class LoginRouter
    {
        const string PATH = "/Login";

        public static IEndpointRouteBuilder MapLogin(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(PATH, async (IMediator mediator, LoginUserRequest request)
                => await mediator.Send(request).ToHttpResult());

            return endpoint;
        }
    }
}
