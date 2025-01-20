using goapp.application.useCase.users.createUser;
using goapp.application.UseCase.ShippingQuotes.CreateShippingQuote;
using goapp.webApi.HttpResult;
using MediatR;

namespace goapp.webApi.Router
{
    public static class ShippingQuoteRouter
    {
        const string PATH = "/ShippingQuote";

        public static IEndpointRouteBuilder MapShippingQuote(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(PATH, async (IMediator mediator, CreateShippingQuoteRequest request)
                => await mediator.Send(request).ToHttpResult());

            return endpoint;
        }
    }
}
