using goapp.application.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.useCase.users.createUser
{
    public record CreateUserRequest(string name, string email, string password) : IRequest<Result<CreateUserResponse>>;
}
