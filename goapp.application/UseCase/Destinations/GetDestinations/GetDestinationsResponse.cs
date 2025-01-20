using goapp.application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.Destinations.GetDestinations
{
    public record GetDestinationsResponse(IEnumerable<DestinationDto> Destinations);

}
