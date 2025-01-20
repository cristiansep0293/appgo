using goapp.application.Data;
using goapp.application.dto;
using goapp.application.Dto;
using goapp.application.useCase.users.createUser;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.Destinations.GetDestinations
{
    public class GetDestinationsRequestHandler : IRequestHandler<GetDestinationsRequest, Result<GetDestinationsResponse>>
    {
        private readonly IGoAppDbContext _goAppDbContext;
        public GetDestinationsRequestHandler(IGoAppDbContext goAppDbContext) 
        {
            _goAppDbContext = goAppDbContext;
        }

        public async Task<Result<GetDestinationsResponse>> Handle(GetDestinationsRequest request, CancellationToken cancellationToken)
        {
            var query = _goAppDbContext.Destinations.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(x => x.description.ToLower().Contains(request.Search.ToLower()));
            }

            var destinations = await query.ToListAsync(cancellationToken);

            var destinationsDtoList = destinations.Select(x => new DestinationDto(x.Id, x.description));

            return new GetDestinationsResponse(destinationsDtoList);
        }
    }
}
