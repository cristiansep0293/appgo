using goapp.application.UseCase.Destinations.GetDestinations;
using goapp.webApi.HttpResult;
using MediatR;

namespace goapp.webApi.Router
{
    public static class DestinationRouter
    {
        const string PATH = "/Destination";

        public static IEndpointRouteBuilder MapDestination(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(PATH, async (IMediator mediator, GetDestinationsRequest request)
                => await mediator.Send(request).ToHttpResult());

            return endpoint;
        }
    }
}
