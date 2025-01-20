using goapp.application.dto;
using goapp.application.UseCase.Destinations.GetDestinations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.UseCase.Users.LoginUser
{
    public record LoginUserRequest(string email, string password) : IRequest<Result<LoginUserResponse>>;
}
