using goapp.application.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.Destinations.GetDestinations
{
    public record GetDestinationsRequest(string? Search, int? Take, int? Skip) : IRequest<Result<GetDestinationsResponse>>;
}
